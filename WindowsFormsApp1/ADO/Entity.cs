using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1.ADO
{
    public partial class Entity : DbContext
    {
        public Entity()
            : base("name=Entity")
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemStatu> ItemStatus { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskItem> TaskItems { get; set; }
        public virtual DbSet<TaskStatu> TaskStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>()
                .Property(e => e.EmployeeID)
                .IsFixedLength();

            modelBuilder.Entity<Announcement>()
                .Property(e => e.val)
                .IsFixedLength();

            modelBuilder.Entity<Building>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Building>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeID)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Fname)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Lname)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Announcements)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeRole>()
                .Property(e => e.EmployeeID)
                .IsFixedLength();

            modelBuilder.Entity<EmployeeSkill>()
                .Property(e => e.EmployeeID)
                .IsFixedLength();

            modelBuilder.Entity<ItemStatu>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ItemStatu>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.ItemStatu)
                .HasForeignKey(e => e.itemStatusID);

            modelBuilder.Entity<ItemType>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<ItemType>()
                .Property(e => e.description)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.role1)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.description)
                .IsFixedLength();

            modelBuilder.Entity<Skill>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Task>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<TaskStatu>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TaskStatu>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<TaskStatu>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.TaskStatu)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
        }
    }
}
