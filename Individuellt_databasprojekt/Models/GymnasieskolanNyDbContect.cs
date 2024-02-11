using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Individuellt_databasprojekt.Models;

public partial class GymnasieskolanNyDbContect : DbContext
{
    public GymnasieskolanNyDbContect()
    {
    }

    public GymnasieskolanNyDbContect(DbContextOptions<GymnasieskolanNyDbContect> options)
        : base(options)
    {
    }

    public virtual DbSet<ScoreReference> ScoreReferences { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblEmployeePosition> TblEmployeePositions { get; set; }

    public virtual DbSet<TblGrade> TblGrades { get; set; }

    public virtual DbSet<TblPosition> TblPositions { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblStudentAttendance> TblStudentAttendances { get; set; }

    public virtual DbSet<TblSubject> TblSubjects { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    public virtual DbSet<VWDepartmentSalary> VWDepartmentSalaries { get; set; }

    public virtual DbSet<VWStudentInfo> VWStudentInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = TOBBE; Initial Catalog = GymnasieskolanNy; Integrated security=true; TrustServerCertificate =True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScoreReference>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Score_reference");

            entity.Property(e => e.Grade)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.MaxScore).HasColumnName("Max_score");
            entity.Property(e => e.MinScore).HasColumnName("Min_score");
            entity.Property(e => e.PassFail)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Pass_fail");
            entity.Property(e => e.ScoreRange)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Score_range");
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Cour__3213E83FFE8B4648");

            entity.ToTable("tbl_Course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Course_Name");
            entity.Property(e => e.SubjectId).HasColumnName("Subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__tbl_Cours__Subje__48CFD27E");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TblCourses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__tbl_Cours__Teach__47DBAE45");
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Depa__3213E83FB5F852BC");

            entity.ToTable("tbl_Department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Department_Name");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Empl__3213E83F3AF7ADC2");

            entity.ToTable("tbl_Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateStart).HasColumnName("Date_Start");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<TblEmployeePosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Employee_Position");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");
            entity.Property(e => e.PositionId).HasColumnName("Position_id");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__tbl_Emplo__Emplo__3C69FB99");

            entity.HasOne(d => d.Position).WithMany()
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__tbl_Emplo__Posit__3D5E1FD2");
        });

        modelBuilder.Entity<TblGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Grad__3213E83FA0FD8FA6");

            entity.ToTable("tbl_Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("Course_id");
            entity.Property(e => e.DateGraded).HasColumnName("Date_Graded");
            entity.Property(e => e.StudentId).HasColumnName("Student_id");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.Course).WithMany(p => p.TblGrades)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__tbl_Grade__Cours__4F7CD00D");

            entity.HasOne(d => d.Student).WithMany(p => p.TblGrades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__tbl_Grade__Stude__4E88ABD4");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TblGrades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__tbl_Grade__Teach__5070F446");
        });

        modelBuilder.Entity<TblPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Posi__3213E83FECA50B88");

            entity.ToTable("tbl_Position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Position_Name");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Stud__3213E83F449B435F");

            entity.ToTable("tbl_Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnrolmentDate).HasColumnName("Enrolment_Date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Personnummer)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<TblStudentAttendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Student_Attendance");

            entity.Property(e => e.CourseId).HasColumnName("Course_id");
            entity.Property(e => e.StudentId).HasColumnName("Student_id");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__tbl_Stude__Cours__4BAC3F29");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__tbl_Stude__Stude__4AB81AF0");
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Subj__3213E83F962A35FC");

            entity.ToTable("tbl_Subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Subject_Name");
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Teac__3213E83F33C927C4");

            entity.ToTable("tbl_Teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

            entity.HasOne(d => d.Department).WithMany(p => p.TblTeachers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_Teach__Depar__4316F928");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblTeachers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_Teach__Emplo__4222D4EF");
        });

        modelBuilder.Entity<VWDepartmentSalary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vW_DepartmentSalary");

            entity.Property(e => e.AverageSalary).HasColumnName("Average_Salary");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("Department_Name");
            entity.Property(e => e.TotalSalary).HasColumnName("Total_Salary");
        });

        modelBuilder.Entity<VWStudentInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vW_StudentInfo");

            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Course_Name");
            entity.Property(e => e.DateGraded).HasColumnName("Date_Graded");
            entity.Property(e => e.Grade)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.GradedBy)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("Graded_By");
            entity.Property(e => e.StudentFullName)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasColumnName("Student_Full_Name");
            entity.Property(e => e.StudentId).HasColumnName("Student_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
