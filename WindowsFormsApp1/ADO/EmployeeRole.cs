namespace WindowsFormsApp1.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeRole
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string EmployeeID { get; set; }

        public int? RoleID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Role Role { get; set; }
    }
}
