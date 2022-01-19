using IndividualProjectPartB.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IndividualProjectPartB
{
    public partial class School : DbContext
    {
        public School()
            : base("name=School")
        {
        }

        public virtual DbSet<Assignment> assignments { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Trainer> trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.assignments)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("assignments_courses").MapLeftKey("course_id").MapRightKey("a_id"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.students)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("students_courses").MapLeftKey("course_id").MapRightKey("student_id"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.trainers)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("trainers_courses").MapLeftKey("course_id").MapRightKey("trainer_id"));

            modelBuilder.Entity<Student>()
                .Property(e => e.tuition_fees)
                .HasPrecision(19, 4);

           
        }
    }
}
