﻿// <auto-generated />
using System;
using CustomerManagament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomerManagament.Infrastructure.Migrations
{
    [DbContext(typeof(CostumerManagementDbContext))]
    [Migration("20231128015707_Added_RoleEntity")]
    partial class Added_RoleEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomerManagement.Core.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UrlFile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StateId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.Tenant", b =>
                {
                    b.Property<Guid>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.City", b =>
                {
                    b.HasOne("CustomerManagement.Core.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.User", b =>
                {
                    b.HasOne("CustomerManagement.Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerManagement.Core.Entities.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("CustomerManagement.Core.Entities.Tenant", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
