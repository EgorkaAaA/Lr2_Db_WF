using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            db.BackerySet.Load();
            Grid.DataSource = db.BackerySet.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Адрес";

        }

        private void StaffSetDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            db.StaffSet.Load();
            Grid.DataSource = db.StaffSet.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Фамилия";
            Grid.Columns[2].HeaderText = "Имя";
            Grid.Columns[3].HeaderText = "Отчество";
        }

        private void ShiftsSetDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            db.ShiftsSet.Load();
            Grid.DataSource = db.ShiftsSet.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Выполнен ли план"; 
            Grid.Columns[2].HeaderText = "Сотрудник";
            Grid.Columns[3].HeaderText = "Булочная";
        }

        private void DeliveriesSetDataGridFill()
        {
            BakeryEntities db = new BakeryEntities();
            db.DeliveriesSet.Load();
            Grid.DataSource = db.DeliveriesSet.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Адресс доставки";
            Grid.Columns[2].HeaderText = "Булочная";
            Grid.Columns[3].HeaderText = "Количестов тортов";
        }                               

        private void DeleteButtom(int rowsCount)
        {
            Grid.Columns[0].HeaderText = "Удалить";
            for (int i = 1; i < rowsCount; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                Grid[0, i] = linkCell;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                BackerySet BackerySet = new BackerySet 
                {
                    adres = textBox1.Text 
                };
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
                StaffSetDataGridFill();
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
                        BackerySet backerySet = db.BackerySet.Find(e.RowIndex);
                        backerySet.adres = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        BackerySetDataGridFill();
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (e.ColumnIndex == 1)
                    {
                        StaffSet staffSet = db.StaffSet.Find(e.RowIndex);
                        staffSet.Surname = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        StaffSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        StaffSet staffSet = db.StaffSet.Find(e.RowIndex);
                        staffSet.name = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        StaffSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        StaffSet staffSet = db.StaffSet.Find(e.RowIndex);
                        staffSet.patronymic = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        StaffSetDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (e.ColumnIndex == 1)
                    {
                        DeliveriesSet deliveriesSet = db.DeliveriesSet.Find(e.RowIndex);
                        deliveriesSet.adres= Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        DeliveriesSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        DeliveriesSet deliveriesSet = db.DeliveriesSet.Find(e.RowIndex);
                        deliveriesSet.Backery_Id = Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString());
                        db.SaveChanges();
                        DeliveriesSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        DeliveriesSet deliveriesSet = db.DeliveriesSet.Find(e.RowIndex);
                        deliveriesSet.numberOfCakes = Convert.ToInt16(Grid[e.ColumnIndex, e.RowIndex].Value.ToString());
                        db.SaveChanges();
                        DeliveriesSetDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (e.ColumnIndex == 1)
                    {
                        ShiftsSet shifts = db.ShiftsSet.Find(e.RowIndex);
                        shifts.Plan = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        ShiftsSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        ShiftsSet shifts = db.ShiftsSet.Find(e.RowIndex);
                        shifts.Backery_Id = Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString());
                        db.SaveChanges();
                        ShiftsSetDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        ShiftsSet shifts = db.ShiftsSet.Find(e.RowIndex);
                        shifts.Staff_Id = Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString());
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
                    BackerySet BackerySet = db.BackerySet.Find(e.RowIndex);
                    db.BackerySet.Remove(BackerySet);
                    db.SaveChanges();
                    BackerySetDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    StaffSet StaffSet = db.StaffSet.Find(e.RowIndex);
                    db.StaffSet.Remove(StaffSet);
                    db.SaveChanges();
                    StaffSetDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    ShiftsSet ShiftsSet = db.ShiftsSet.Find(e.RowIndex);
                    db.ShiftsSet.Remove(ShiftsSet);
                    db.SaveChanges();
                    ShiftsSetDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    DeliveriesSet DeliveriesSet = db.DeliveriesSet.Find(e.RowIndex);
                    db.DeliveriesSet.Remove(DeliveriesSet);
                    db.SaveChanges();
                    DeliveriesSetDataGridFill();
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
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
                    StaffSetDataGridFill();
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
    }
}
