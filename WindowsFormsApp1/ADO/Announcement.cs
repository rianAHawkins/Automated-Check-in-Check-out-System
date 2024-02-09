namespace WindowsFormsApp1.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Announcement")]
    public partial class Announcement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeID { get; set; }

        [Required]
        [StringLength(250)]
        public string val { get; set; }

        public DateTime created { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
