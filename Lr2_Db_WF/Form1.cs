using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr2_Db_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Invisible();
        }

        private void Invisible()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void BackerySetDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            int b = 0;
            foreach (var a in db.BackerySet)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 2;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Адрес";
            Grid.ColumnHeadersVisible = false;


            foreach (var k in db.BackerySet)
            {
                Grid.Rows[i].Cells[1].Value = k.adres;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void manufactureDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            int b = 0;
            foreach (var a in db.StaffSet)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Фамилия";
            Grid.Rows[0].Cells[2].Value = "Имя";
            Grid.Rows[0].Cells[3].Value = "Отчество";
            Grid.ColumnHeadersVisible = false;


            foreach (var m in db.StaffSet)
            {
                Grid.Rows[i].Cells[1].Value = m.Surname;
                Grid.Rows[i].Cells[2].Value = m.name;
                Grid.Rows[i].Cells[3].Value = m.patronymic;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void ShiftsSetDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            int b = 0;
            foreach (var a in db.ShiftsSet)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Выполнен ли план";
            Grid.Rows[0].Cells[2].Value = "Сотрудник";
            Grid.Rows[0].Cells[3].Value = "Булочная";
            Grid.ColumnHeadersVisible = false;


            foreach (var f in db.ShiftsSet)
            {
                Grid.Rows[i].Cells[1].Value = f.Plan;
                Grid.Rows[i].Cells[2].Value = f.Staff_Id;
                Grid.Rows[i].Cells[3].Value = f.Backery_Id; ;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void DeliveriesSetDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            int b = 0;
            foreach (var a in db.DeliveriesSet)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Адресс доставки";
            Grid.Rows[0].Cells[2].Value = "Булочная";
            Grid.Rows[0].Cells[3].Value = "Количестов тортов";
            Grid.ColumnHeadersVisible = false;


            foreach (var d in db.DeliveriesSet)
            {
                Grid.Rows[i].Cells[1].Value = d.adres;
                Grid.Rows[i].Cells[2].Value = d.Backery_Id;
                Grid.Rows[i].Cells[3].Value = d.numberOfCakes;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void DeleteButtom(int rowsCount)
        {
            for (int i = 1; i < rowsCount; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                Grid[0, i] = linkCell;
                Grid[0, i].Value = "Удалить";
            }
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                if (comboBox1.SelectedIndex == 0)
                {
                    Invisible();
                    BackerySetDataGridFill();
                    label1.Visible = true;
                    label1.Text = "Адрес: ";
                    textBox1.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Invisible();
                    manufactureDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Фамилия";
                    label2.Text = "Имя";
                    label3.Text = "Отчество";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Invisible();
                    ShiftsSetDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Выполнен ли план";
                    label2.Text = "Сотрудник";
                    label3.Text = "Булочная";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Invisible();
                    DeliveriesSetDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Адресс доставки";
                    label2.Text = "Булочная";
                    label3.Text = "Количестов тортов";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
        }

        private void comboBox1_MouseLeave_1(object sender, EventArgs e)
        {
            comboBox1_MouseLeave(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                BackerySet BackerySet = new BackerySet { adres = textBox1.Text };
                BackerySet.BackerySetAdd(BackerySet);
                BackerySetDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                StaffSet StaffSet = new StaffSet
                {
                    Surname = textBox1.Text,
                    name = textBox2.Text,
                    patronymic = textBox3.Text
                };
                StaffSet.StaffSetAdd(StaffSet);
                manufactureDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                ShiftsSet ShiftsSet = new ShiftsSet
                {
                    Plan = textBox1.Text,
                    Backery_Id = Convert.ToInt32(textBox3.Text),
                    Staff_Id = Convert.ToInt32(textBox2.Text)
                };
                ShiftsSet.ShiftsSetAdd(ShiftsSet);
                ShiftsSetDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                DeliveriesSet DeliveriesSet = new DeliveriesSet
                {
                    adres = textBox1.Text,
                    Backery_Id = Convert.ToInt32(textBox2.Text),
                    numberOfCakes = Convert.ToInt16(textBox3.Text)
                };
                DeliveriesSet.DeliveriesSetAdd(DeliveriesSet);
                DeliveriesSetDataGridFill();
            }
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            BakeryEntities db = new BakeryEntities();
            if (checkBox1.Checked)
                if (comboBox1.SelectedIndex == 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.BackerySet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.adres = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        BackerySetDataGridFill();
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.StaffSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Surname = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.StaffSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.name = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.StaffSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.patronymic = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.DeliveriesSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.adres = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        DeliveriesSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.DeliveriesSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Backery_Id = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                            }
                            i++;
                        }
                        db.SaveChanges();
                        DeliveriesSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.DeliveriesSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.BackerySet)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.Backery_Id = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        DeliveriesSetDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.ShiftsSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Plan = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        ShiftsSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.ShiftsSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.BackerySet)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.Backery_Id = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        ShiftsSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.ShiftsSet)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.StaffSet)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.Staff_Id = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        ShiftsSetDataGridFill();
                    }
                }
        }

        private void Grid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BakeryEntities db = new BakeryEntities();
            if (e.ColumnIndex == 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    int i = 0;
                    BackerySet BackerySet = new BackerySet();
                    foreach (var a in db.BackerySet)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            BackerySet = a;
                        }
                        i++;

                    }
                    db.BackerySet.Remove(BackerySet);
                    db.SaveChanges();
                    BackerySetDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    int i = 0;
                    StaffSet StaffSet = new StaffSet();
                    foreach (var a in db.StaffSet)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            StaffSet = a;
                        }
                        i++;
                    }
                    db.StaffSet.Remove(StaffSet);
                    db.SaveChanges();
                    manufactureDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    int i = 0;
                    ShiftsSet ShiftsSet = new ShiftsSet();
                    foreach (var a in db.ShiftsSet)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            ShiftsSet = a;
                        }
                        i++;
                    }
                    db.ShiftsSet.Remove(ShiftsSet);
                    db.SaveChanges();
                    ShiftsSetDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    int i = 0;
                    DeliveriesSet DeliveriesSet = new DeliveriesSet();
                    foreach (var a in db.DeliveriesSet)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            DeliveriesSet = a;
                        }
                        i++;
                    }
                    db.DeliveriesSet.Remove(DeliveriesSet);
                    db.SaveChanges();
                    DeliveriesSetDataGridFill();
                }
            }
        }
    }
}
