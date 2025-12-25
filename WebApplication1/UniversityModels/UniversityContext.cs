using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.UniversityModels;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdmissionApplication> AdmissionApplications { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CrsResult> CrsResults { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Laboratory> Laboratories { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourceAllocation> ResourceAllocations { get; set; }

    public virtual DbSet<RoomReservation> RoomReservations { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<Transcript> Transcripts { get; set; }

    public virtual DbSet<Value> Values { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MAHMOUD-NASHAAT\\SQLEXPRESS;Database=UNN;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Admissio__C93A4F79C76A000A");

            entity.ToTable("AdmissionApplication");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicationStatus).HasMaxLength(20);
            entity.Property(e => e.NationalId)
                .HasMaxLength(20)
                .HasColumnName("NationalID");
            entity.Property(e => e.StudentName).HasMaxLength(100);
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementId).HasName("PK__Announce__9DE445549D5256B2");

            entity.ToTable("Announcement");

            entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PK__Attribut__C189298AAAA01AD6");

            entity.ToTable("Attribute");

            entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
            entity.Property(e => e.AttributeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__Classroo__11618E8A4E6E3A93");

            entity.ToTable("Classroom");

            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.RoomNumber).HasMaxLength(20);
            entity.Property(e => e.RoomType).HasMaxLength(20);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.departmentId, "IX_Courses_departmentId");

            entity.Property(e => e.degree).HasColumnName("degree");
            entity.Property(e => e.departmentId).HasColumnName("departmentId");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses).HasForeignKey(d => d.departmentId);

            entity.HasMany(d => d.Courses).WithMany(p => p.Prerequisites)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Cours__00750D23"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Prere__0169315C"),
                    j =>
                    {
                        j.HasKey("CourseId", "PrerequisiteId").HasName("PK__CoursePr__4B77E4B86AA992C2");
                        j.ToTable("CoursePrerequisite");
                        j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");
                        j.IndexerProperty<int>("PrerequisiteId").HasColumnName("PrerequisiteID");
                    });

            entity.HasMany(d => d.Prerequisites).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Prere__0169315C"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Cours__00750D23"),
                    j =>
                    {
                        j.HasKey("CourseId", "PrerequisiteId").HasName("PK__CoursePr__4B77E4B86AA992C2");
                        j.ToTable("CoursePrerequisite");
                        j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");
                        j.IndexerProperty<int>("PrerequisiteId").HasColumnName("PrerequisiteID");
                    });
        });

        modelBuilder.Entity<CrsResult>(entity =>
        {
            entity.ToTable("crsResult");

            entity.HasIndex(e => e.CourseId, "IX_crsResult_CourseId");

            entity.HasIndex(e => e.TraineeId, "IX_crsResult_TraineeId");

            entity.HasOne(d => d.Course).WithMany(p => p.CrsResults)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Trainee).WithMany(p => p.CrsResults)
                .HasForeignKey(d => d.TraineeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Manager).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.EntityId).HasName("PK__Entity__9C892FFD5BD14C3C");

            entity.ToTable("Entity");

            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.EntityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OriginalId).HasColumnName("OriginalID");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C870240958C2");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(100);
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_Instructors_CourseId");

            entity.HasIndex(e => e.DepartmentId, "IX_Instructors_DepartmentId");

            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Course).WithMany(p => p.Instructors).HasForeignKey(d => d.CourseId);

            entity.HasOne(d => d.Department).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Laboratory>(entity =>
        {
            entity.HasKey(e => e.LabId).HasName("PK__Laborato__EDBD773AD27AD4FE");

            entity.ToTable("Laboratory");

            entity.Property(e => e.LabId).HasColumnName("LabID");
            entity.Property(e => e.LabName).HasMaxLength(50);
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__LeaveReq__796DB979B035AAC9");

            entity.ToTable("LeaveRequest");

            entity.Property(e => e.LeaveId).HasColumnName("LeaveID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Staff).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__LeaveRequ__Staff__0AF29B96");
        });

        modelBuilder.Entity<MaintenanceRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Maintena__33A8519A983F0F1F");

            entity.ToTable("MaintenanceRequest");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.IssueDescription).HasMaxLength(255);
            entity.Property(e => e.ReportedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Classroom).WithMany(p => p.MaintenanceRequests)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__Maintenan__Class__64CCF2AE");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C037C02ACBBA9");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.MessageText).HasMaxLength(500);
            entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
            entity.Property(e => e.ReceiverType).HasMaxLength(20);
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SenderType).HasMaxLength(20);
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK__Payroll__99DFC692068414EA");

            entity.ToTable("Payroll");

            entity.Property(e => e.PayrollId).HasColumnName("PayrollID");
            entity.Property(e => e.PayDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Staff).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Payroll__StaffID__08162EEB");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1814F29FF4247");

            entity.ToTable("Resource");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.ResourceName).HasMaxLength(50);
            entity.Property(e => e.ResourceType).HasMaxLength(30);
        });

        modelBuilder.Entity<ResourceAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__Resource__B3C6D6AB1E5F6734");

            entity.ToTable("ResourceAllocation");

            entity.Property(e => e.AllocationId).HasColumnName("AllocationID");
            entity.Property(e => e.AllocatedToId).HasColumnName("AllocatedToID");
            entity.Property(e => e.AllocatedToType).HasMaxLength(20);
            entity.Property(e => e.AllocationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceAllocations)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("FK__ResourceA__Resou__7132C993");
        });

        modelBuilder.Entity<RoomReservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__RoomRese__B7EE5F04E113F629");

            entity.ToTable("RoomReservation");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(100);
            entity.Property(e => e.ReservedBy).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Classroom).WithMany(p => p.RoomReservations)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__RoomReser__Class__60FC61CA");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7BF56C6F5");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Staff__Departmen__04459E07");
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Trainees_DepartmentId");

            entity.HasOne(d => d.Department).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Transcript>(entity =>
        {
            entity.HasKey(e => e.TranscriptId).HasName("PK__Transcri__FD083EF3FA49B1E3");

            entity.ToTable("Transcript");

            entity.Property(e => e.TranscriptId).HasColumnName("TranscriptID");
            entity.Property(e => e.GeneratedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.Transcripts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Transcrip__Stude__6B79F03D");
        });

        modelBuilder.Entity<Value>(entity =>
        {
            entity.HasKey(e => e.ValueId).HasName("PK__Value__93364E68F843A009");

            entity.ToTable("Value");

            entity.Property(e => e.ValueId).HasColumnName("ValueID");
            entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
            entity.Property(e => e.AttributeValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EntityId).HasColumnName("EntityID");

            entity.HasOne(d => d.Attribute).WithMany(p => p.Values)
                .HasForeignKey(d => d.AttributeId)
                .HasConstraintName("FK__Value__Attribute__12C8C788");

            entity.HasOne(d => d.Entity).WithMany(p => p.Values)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Value__EntityID__11D4A34F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



}
