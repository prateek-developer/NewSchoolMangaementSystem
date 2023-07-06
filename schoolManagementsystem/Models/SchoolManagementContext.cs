using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace schoolManagementsystem.Models
{
    public partial class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext()
        {
        }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<LeaveDetail> LeaveDetails { get; set; }
        public virtual DbSet<LoginDetail> LoginDetails { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<StudentAttendanceDetail> StudentAttendanceDetails { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
        public virtual DbSet<TeachersDetail> TeachersDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server= PRATEEK;  database=SchoolManagement;  trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName).IsUnicode(false);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLASS__teacher_i__3F466844");
            });

            modelBuilder.Entity<LeaveDetail>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("PK__leave_de__743350BCE383BF42");

                entity.HasOne(d => d.AppliedByNavigation)
                    .WithMany(p => p.LeaveDetails)
                    .HasForeignKey(d => d.AppliedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leave_det__appli__440B1D61");
            });

            modelBuilder.Entity<LoginDetail>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__login_de__C2CA7DB3E283527A");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.Property(e => e.NoticeDetails).IsUnicode(false);

                entity.HasOne(d => d.IssuedByNavigation)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.IssuedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NOTICE__issued_b__5165187F");
            });

            modelBuilder.Entity<StudentAttendanceDetail>(entity =>
            {
                entity.HasKey(e => e.AttendanceId)
                    .HasName("PK__student___20D6A96866532ADC");

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAttendanceDetails)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__student_a__stude__49C3F6B7");
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Student___A2F7EDF4AE8E096D");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Student_d__login__398D8EEE");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SubjectClassTeacherRelationship>(entity =>
            {
                entity.HasKey(e => e.SctId)
                    .HasName("PK__Subject___68F019F46074F410");

                entity.Property(e => e.SctId).ValueGeneratedNever();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubjectClassTeacherRelationships)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Subject_c__class__4E88ABD4");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SubjectClassTeacherRelationships)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Subject_c__stude__4D94879B");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectClassTeacherRelationships)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Subject_c__teach__4CA06362");
            });

            modelBuilder.Entity<TeachersDetail>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK__teachers__03AE777E03EE2080");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Password).IsFixedLength(true);

                entity.Property(e => e.SubjectTaught)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TeachersDetails)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__teachers___login__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
