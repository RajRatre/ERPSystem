﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPWebAPI.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccTransaction> AccTransactions { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Individual> Individuals { get; set; }

    public virtual DbSet<Officer> Officers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=EMPLOYEE\n;Trusted_Connection=False; TrustServerCertificate=True;User Id=sa;Password=India@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccTransaction>(entity =>
        {
            entity.HasKey(e => e.TxnId).HasName("PK__ACC_TRAN__C512E7E232F82F0F");

            entity.ToTable("ACC_TRANSACTION");

            entity.Property(e => e.TxnId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("TXN_ID");
            entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.ExecutionBranchId).HasColumnName("EXECUTION_BRANCH_ID");
            entity.Property(e => e.FundsAvailDate)
                .HasColumnType("datetime")
                .HasColumnName("FUNDS_AVAIL_DATE");
            entity.Property(e => e.TellerEmpId).HasColumnName("TELLER_EMP_ID");
            entity.Property(e => e.TxnDate)
                .HasColumnType("datetime")
                .HasColumnName("TXN_DATE");
            entity.Property(e => e.TxnTypeCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TXN_TYPE_CD");

            entity.HasOne(d => d.Account).WithMany(p => p.AccTransactions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("ACC_TRANSACTION_ACCOUNT_FK");

            entity.HasOne(d => d.ExecutionBranch).WithMany(p => p.AccTransactions)
                .HasForeignKey(d => d.ExecutionBranchId)
                .HasConstraintName("ACC_TRANSACTION_BRANCH_FK");

            entity.HasOne(d => d.TellerEmp).WithMany(p => p.AccTransactions)
                .HasForeignKey(d => d.TellerEmpId)
                .HasConstraintName("ACC_TRANSACTION_EMPLOYEE_FK");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__ACCOUNT__05B22F60BABA3F88");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.AvailBalance).HasColumnName("AVAIL_BALANCE");
            entity.Property(e => e.CloseDate)
                .HasColumnType("datetime")
                .HasColumnName("CLOSE_DATE");
            entity.Property(e => e.CustId).HasColumnName("CUST_ID");
            entity.Property(e => e.LastActivityDate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_ACTIVITY_DATE");
            entity.Property(e => e.OpenBranchId).HasColumnName("OPEN_BRANCH_ID");
            entity.Property(e => e.OpenDate)
                .HasColumnType("datetime")
                .HasColumnName("OPEN_DATE");
            entity.Property(e => e.OpenEmpId).HasColumnName("OPEN_EMP_ID");
            entity.Property(e => e.PendingBalance).HasColumnName("PENDING_BALANCE");
            entity.Property(e => e.ProductCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_CD");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Cust).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("ACCOUNT_CUSTOMER_FK");

            entity.HasOne(d => d.OpenBranch).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.OpenBranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ACCOUNT_BRANCH_FK");

            entity.HasOne(d => d.OpenEmp).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.OpenEmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ACCOUNT_EMPLOYEE_FK");

            entity.HasOne(d => d.ProductCdNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ProductCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ACCOUNT_PRODUCT_FK");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__BRANCH__766E0D23B5F901FD");

            entity.ToTable("BRANCH");

            entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ZIP_CODE");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__BUSINESS__93ABC003C4635D2A");

            entity.ToTable("BUSINESS");

            entity.Property(e => e.CustId)
                .ValueGeneratedNever()
                .HasColumnName("CUST_ID");
            entity.Property(e => e.IncorpDate)
                .HasColumnType("datetime")
                .HasColumnName("INCORP_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.StateId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATE_ID");

            entity.HasOne(d => d.Cust).WithOne(p => p.Business)
                .HasForeignKey<Business>(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BUSINESS_EMPLOYEE_FK");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__CUSTOMER__93ABC003E1CAA403");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustId).HasColumnName("CUST_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.CustTypeCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CUST_TYPE_CD");
            entity.Property(e => e.FedId)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("FED_ID");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("POSTAL_CODE");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATE");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DEPARTME__512A59ACF33D05B5");

            entity.ToTable("DEPARTMENT");

            entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EMPLOYEE__16EBFA26C8711EE1");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.EmpId).HasColumnName("EMP_ID");
            entity.Property(e => e.AssignedBranchId).HasColumnName("ASSIGNED_BRANCH_ID");
            entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("START_DATE");
            entity.Property(e => e.SuperiorEmpId).HasColumnName("SUPERIOR_EMP_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.AssignedBranch).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AssignedBranchId)
                .HasConstraintName("EMPLOYEE_BRANCH_FK");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("EMPLOYEE_DEPARTMENT_FK");

            entity.HasOne(d => d.SuperiorEmp).WithMany(p => p.InverseSuperiorEmp)
                .HasForeignKey(d => d.SuperiorEmpId)
                .HasConstraintName("EMPLOYEE_EMPLOYEE_FK");
        });

        modelBuilder.Entity<Individual>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__INDIVIDU__93ABC003A301AC06");

            entity.ToTable("INDIVIDUAL");

            entity.Property(e => e.CustId)
                .ValueGeneratedNever()
                .HasColumnName("CUST_ID");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("BIRTH_DATE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");

            entity.HasOne(d => d.Cust).WithOne(p => p.Individual)
                .HasForeignKey<Individual>(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("INDIVIDUAL_CUSTOMER_FK");
        });

        modelBuilder.Entity<Officer>(entity =>
        {
            entity.HasKey(e => e.OfficerId).HasName("PK__OFFICER__65E4F3D7B1635E0A");

            entity.ToTable("OFFICER");

            entity.Property(e => e.OfficerId).HasColumnName("OFFICER_ID");
            entity.Property(e => e.CustId).HasColumnName("CUST_ID");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("END_DATE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("START_DATE");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Cust).WithMany(p => p.Officers)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("OFFICER_CUSTOMER_FK");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductCd).HasName("PK__PRODUCT__52B466A4F050D3AF");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.ProductCd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_CD");
            entity.Property(e => e.DateOffered)
                .HasColumnType("datetime")
                .HasColumnName("DATE_OFFERED");
            entity.Property(e => e.DateRetired)
                .HasColumnType("datetime")
                .HasColumnName("DATE_RETIRED");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.ProductTypeCd)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_TYPE_CD");

            entity.HasOne(d => d.ProductTypeCdNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeCd)
                .HasConstraintName("PRODUCT_PRODUCT_TYPE_FK");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeCd).HasName("PK__PRODUCT___A60F3DC91D89FBE4");

            entity.ToTable("PRODUCT_TYPE");

            entity.Property(e => e.ProductTypeCd)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_TYPE_CD");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
