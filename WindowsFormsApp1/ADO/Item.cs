namespace WindowsFormsApp1.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? BuildingID { get; set; }

        public int? itemTypeID { get; set; }

        public int? itemStatusID { get; set; }

        public DateTime? updated { get; set; }

        public virtual Building Building { get; set; }

        public virtual ItemStatus ItemStatu { get; set; }

        public virtual ItemType ItemType { get; set; }
    }
}
