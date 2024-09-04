﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WILTestDesignSpace.Models;

public partial class BumbleBeesContext : DbContext
{
    public BumbleBeesContext()
    {
    }

    public BumbleBeesContext(DbContextOptions<BumbleBeesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminTask> AdminTasks { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=RADHYA_LAPTOP\\SQLEXPRESS;Initial Catalog=BumbleBees;Encrypt=False;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Admin_Ta__716F4ACDAB1D63E0");

            entity.ToTable("Admin_Task");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("Task_ID");
            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.TaskDate).HasColumnName("Task_Date");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Task_Name");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminTasks)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__Admin_Tas__Admin__4E88ABD4");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin_Us__4A300117A62C0597");

            entity.ToTable("Admin_User");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("Admin_ID");
            entity.Property(e => e.CertifiedId).HasColumnName("Certified_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fuuid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FUUID");

            entity.HasOne(d => d.Fuu).WithMany(p => p.AdminUsers)
                .HasForeignKey(d => d.Fuuid)
                .HasConstraintName("FK__Admin_Use__FUUID__4BAC3F29");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryName).HasName("PK__Category__B35EB41808600F0B");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyRegNo).HasName("PK__Company__16298F5CD9D5645C");

            entity.ToTable("Company");

            entity.HasIndex(e => e.Fuuid, "UQ__Company__EDE3AC3CDB1AD3DF").IsUnique();

            entity.Property(e => e.CompanyRegNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Company_RegNo");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
            entity.Property(e => e.CompanyTelephone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Company_Telephone");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fuuid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FUUID");
            entity.Property(e => e.TaxNo).HasColumnName("Tax_No");

            entity.HasOne(d => d.Fuu).WithOne(p => p.Company)
                .HasForeignKey<Company>(d => d.Fuuid)
                .HasConstraintName("FK__Company__FUUID__398D8EEE");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__513A0475185AFB35");

            entity.ToTable("Document");

            entity.Property(e => e.DocumentId)
                .ValueGeneratedNever()
                .HasColumnName("Document_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
            entity.Property(e => e.DocumentDate).HasColumnName("Document_Date");
            entity.Property(e => e.FirebaseUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Firebase_URL");
            entity.Property(e => e.Fuuid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FUUID");

            entity.HasOne(d => d.CategoryNameNavigation).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CategoryName)
                .HasConstraintName("FK__Document__Catego__3F466844");

            entity.HasOne(d => d.Fuu).WithMany(p => p.Documents)
                .HasForeignKey(d => d.Fuuid)
                .HasConstraintName("FK__Document__FUUID__3E52440B");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Donation__E3A7BA9238D20398");

            entity.ToTable("Donation");

            entity.Property(e => e.DonationId)
                .ValueGeneratedNever()
                .HasColumnName("Donation_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CompanyRegNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Company_RegNo");
            entity.Property(e => e.DonationDate).HasColumnName("Donation_Date");

            entity.HasOne(d => d.CompanyRegNoNavigation).WithMany(p => p.Donations)
                .HasForeignKey(d => d.CompanyRegNo)
                .HasConstraintName("FK__Donation__Compan__48CFD27E");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.OrganisationRegNo).HasName("PK__Organisa__1ACE868E81835E32");

            entity.ToTable("Organisation");

            entity.HasIndex(e => e.Fuuid, "UQ__Organisa__EDE3AC3C79070C04").IsUnique();

            entity.Property(e => e.OrganisationRegNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Organisation_regNo");
            entity.Property(e => e.DirectorContactNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Director_ContactNo");
            entity.Property(e => e.DirectorFullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Director_FullName");
            entity.Property(e => e.DirectorIdnumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Director_IDNumber");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fuuid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FUUID");

            entity.HasOne(d => d.Fuu).WithOne(p => p.Organisation)
                .HasForeignKey<Organisation>(d => d.Fuuid)
                .HasConstraintName("FK__Organisat__FUUID__4316F928");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Project__1CB92FE3180DEA70");

            entity.ToTable("Project");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("Project_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Image_URL");
            entity.Property(e => e.OrganisationRegNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Organisation_regNo");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_Date");
            entity.Property(e => e.ProjectDate).HasColumnName("Project_Date");
            entity.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("Project_Description");
            entity.Property(e => e.ProjectStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Project_Status");

            entity.HasOne(d => d.OrganisationRegNoNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OrganisationRegNo)
                .HasConstraintName("FK__Project__Organis__45F365D3");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Fuuid).HasName("PK__User_Pro__EDE3AC3D3F4BEACD");

            entity.ToTable("User_Profile");

            entity.Property(e => e.Fuuid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FUUID");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
