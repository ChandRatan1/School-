using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVCWithEFCF3.Models
{

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("Constr")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolDbContext>());
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().MapToStoredProcedures(S => S.Insert(X => X.HasName("Insert_Student")));
            modelBuilder.Entity<Student>().MapToStoredProcedures(S => S.Update(X => X.HasName("Update_Student")));
            modelBuilder.Entity<Student>().MapToStoredProcedures(S => S.Delete(X => X.HasName("Delete_Student")));

        }
    }


}