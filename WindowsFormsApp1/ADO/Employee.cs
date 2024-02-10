namespace WindowsFormsApp1.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Announcements = new HashSet<Announcement>();
            EmployeeRoles = new HashSet<EmployeeRole>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        [StringLength(10)]
        public string EmployeeID { get; set; }

        [Required]
        [StringLength(25)]
        public string Fname { get; set; }

        [Required]
        [StringLength(25)]
        public string Lname { get; set; }

        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Announcement> Announcements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
