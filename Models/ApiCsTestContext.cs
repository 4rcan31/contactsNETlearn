using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace contactsNETlearn.Models;

public partial class ApiCsTestContext : DbContext
{
    public ApiCsTestContext()
    {
    }

    public ApiCsTestContext(DbContextOptions<ApiCsTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=api_cs_test;User Id=sa;Password=<YourPassword>;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1B3D7D6D0C");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(255);

            entity.HasOne(d => d.Contact).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Addresses__Conta__403A8C7D");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C6625BBCD34B5D8");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasMany(d => d.Groups).WithMany(p => p.Contacts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContactGroup",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContactGr__Group__45F365D3"),
                    l => l.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContactGr__Conta__44FF419A"),
                    j =>
                    {
                        j.HasKey("ContactId", "GroupId").HasName("PK__ContactG__ED2F8A8B58F4982E");
                        j.ToTable("ContactGroups");
                        j.IndexerProperty<int>("ContactId").HasColumnName("ContactID");
                        j.IndexerProperty<int>("GroupId").HasColumnName("GroupID");
                    });
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__Emails__7ED91AEF3F6521C6");

            entity.Property(e => e.EmailId).HasColumnName("EmailID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Email1)
                .HasMaxLength(255)
                .HasColumnName("Email");
            entity.Property(e => e.EmailType).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Emails)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Emails__ContactI__3D5E1FD2");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF30A0C4B8CA5");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.GroupName).HasMaxLength(100);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("PK__Phones__F3EE4BD0C590878A");

            entity.Property(e => e.PhoneId).HasColumnName("PhoneID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.PhoneType).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Phones)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Phones__ContactI__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
