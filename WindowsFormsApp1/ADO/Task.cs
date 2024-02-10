namespace WindowsFormsApp1.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            TaskItems = new HashSet<TaskItem>();
        }

        public int ID { get; set; }

        public int BuildingID { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int SkillID { get; set; }

        public int StatusID { get; set; }

        public virtual Building Building { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual TaskStatu TaskStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskItem> TaskItems { get; set; }
    }
}
