//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lr2_Db_WF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShiftsSet
    {
        public int Id { get; set; }
        public string Plan { get; set; }
        public int Staff_Id { get; set; }
        public int Backery_Id { get; set; }
    
        public virtual BackerySet BackerySet { get; set; }
        public virtual StaffSet StaffSet { get; set; }

        public void ShiftsSetAdd (ShiftsSet shifts)
        {
            using (BakeryEntities db = new BakeryEntities())
            {
                db.ShiftsSet.Add(shifts);
                db.SaveChanges();
            }
        }
    }
}