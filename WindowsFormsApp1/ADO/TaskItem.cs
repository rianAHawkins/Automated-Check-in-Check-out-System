namespace WindowsFormsApp1.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaskItem
    {
        public int ID { get; set; }

        public int? TaskID { get; set; }

        public int? itemTypeID { get; set; }

        public int? Required { get; set; }

        public virtual ItemType ItemType { get; set; }

        public virtual Task Task { get; set; }
    }
}
