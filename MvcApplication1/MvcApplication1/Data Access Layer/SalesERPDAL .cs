using System;
using System.Data.Entity;
using MvcApplication1.Models;
namespace MvcApplication1.DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }

        //public SalesERPDAL():base("NewName")
        //{

        //}

    }

}

