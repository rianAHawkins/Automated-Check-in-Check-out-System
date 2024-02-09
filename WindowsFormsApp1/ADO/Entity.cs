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
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemStatus> ItemStatus { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

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

            modelBuilder.Entity<ItemStatus>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<ItemStatus>()
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
        }
    }
}
