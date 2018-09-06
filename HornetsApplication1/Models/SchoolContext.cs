using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HornetsApplication1.Models
{
    public partial class SchoolContext : DbContext
    {
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public SchoolContext(DbContextOptions<SchoolContext> options)
    : base(options)
        { }


        // Unable to generate entity type for table 'dbo.InstitutionDetails'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Contact'. Please see the warning messages.
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ExamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.FacultyId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FacultyAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyContact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyDesignation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyImage).IsUnicode(false);

                entity.Property(e => e.FacultyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyQualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.ResultId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnType("date");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Result_Class");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Result_Exam");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Result_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Result_Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(10);

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacultyId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Subject_Class");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_Subject_Faculty");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Transaction_Student");
            });
        }
    }
}
