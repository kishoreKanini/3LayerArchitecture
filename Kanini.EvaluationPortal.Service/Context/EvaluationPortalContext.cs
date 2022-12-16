using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.Service.Context
{

    public partial class EvaluationPortalContext : DbContext
    {
        public EvaluationPortalContext()
        {
        }

        public EvaluationPortalContext(DbContextOptions<EvaluationPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<QuestionBank> QuestionBanks { get; set; } = null!;

        public virtual DbSet<QuestionPattern> QuestionPatterns { get; set; } = null!;

        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        public virtual DbSet<TestAttendeeHistory> TestAttendeeHistories { get; set; } = null!;

        public virtual DbSet<TestHistory> TestHistories { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){

            }
        }
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //         => optionsBuilder.UseSqlServer("Server =(localdb)\\MSSQLLocalDB;Database = EvaluationPortal;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionBank>(entity =>
            {
                entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC71ED02E8");

                entity.ToTable("QuestionBank");

                entity.Property(e => e.QuestionLevel).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Subject).WithMany(p => p.QuestionBanks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__QuestionB__Subje__693CA210");
            });

            modelBuilder.Entity<QuestionPattern>(entity =>
            {
                entity.HasKey(e => e.QuestionPatternId).HasName("PK__Question__3214EC07A5BE1CB0");

                entity.ToTable("QuestionPattern");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA3A8E622F09A");

                entity.ToTable("Subject");

                entity.HasIndex(e => e.SubjectName, "UQ__Subject__4C5A7D5529ABF3C7").IsUnique();

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestAttendeeHistory>(entity =>
            {
                entity.HasKey(e => e.QuestionPaperCode).HasName("PK__TestAtte__F3E9C6A0C9C287A5");

                entity.ToTable("TestAttendeeHistory");

                entity.Property(e => e.DateOfExam).HasColumnType("date");
                entity.Property(e => e.ExamEndTime).HasColumnType("datetime");
                entity.Property(e => e.ExamStartTime).HasColumnType("datetime");

                entity.HasOne(d => d.QuestionPattern).WithMany(p => p.TestAttendeeHistories)
                    .HasForeignKey(d => d.QuestionPatternId)
                    .HasConstraintName("FK__TestAtten__Quest__17036CC0");

                entity.HasOne(d => d.Subject).WithMany(p => p.TestAttendeeHistories)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__TestAtten__Subje__17F790F9");

                entity.HasOne(d => d.User).WithMany(p => p.TestAttendeeHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__TestAtten__UserI__18EBB532");
            });

            modelBuilder.Entity<TestHistory>(entity =>
            {
                entity.HasKey(e => e.SerialNumber).HasName("PK__TestHist__048A0009A98BF8D1");

                entity.ToTable("TestHistory");

                entity.HasOne(d => d.Question).WithMany(p => p.TestHistories)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__TestHisto__Quest__1CBC4616");

                entity.HasOne(d => d.QuestionPaperCodeNavigation).WithMany(p => p.TestHistories)
                    .HasForeignKey(d => d.QuestionPaperCode)
                    .HasConstraintName("FK__TestHisto__Quest__1BC821DD");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CEB1EB98C");

                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D10534966C8410").IsUnique();

                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(30);
                entity.Property(e => e.Password).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

