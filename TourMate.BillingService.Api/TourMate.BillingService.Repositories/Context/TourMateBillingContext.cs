using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TourMate.BillingService.Repositories.Models;

namespace TourMate.BillingService.Repositories.Context;

public partial class TourMateBillingContext : DbContext
{
    public TourMateBillingContext()
    {
    }

    public TourMateBillingContext(DbContextOptions<TourMateBillingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Revenue> Revenues { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Payment");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");
            entity.Property(e => e.MembershipPackageId).HasColumnName("membershipPackageId");
            entity.Property(e => e.PaymentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("paymentId");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .HasColumnName("paymentType");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Revenue>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Revenue");

            entity.Property(e => e.ActualReceived).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");
            entity.Property(e => e.PlatformCommission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RevenueId).ValueGeneratedOnAdd();
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
