﻿// <auto-generated />
using System;
using Flexio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flexio.Migrations.Migrations
{
    [DbContext(typeof(FlexioContext))]
    [Migration("20220228234610_UpdateUserDetailMadeCreatorAndActualOwnerOptional")]
    partial class UpdateUserDetailMadeCreatorAndActualOwnerOptional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flexio.Data.Models.ApplicationVersions.ApplicationVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ApplicationVersions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Create Skeleton",
                            Version = "1.0.1"
                        });
                });

            modelBuilder.Entity("Flexio.Data.Models.Users.RoleLookup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RoleLookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "FlexioAdmin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Client"
                        },
                        new
                        {
                            Id = 3,
                            Name = "IdentityChecker"
                        });
                });

            modelBuilder.Entity("Flexio.Data.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Flexio.Data.Models.Users.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActualOwnerId")
                        .IsUnique()
                        .HasFilter("[ActualOwnerId] IS NOT NULL");

                    b.HasIndex("CreatorId")
                        .IsUnique()
                        .HasFilter("[CreatorId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Flexio.Data.Models.Users.UserDetail", b =>
                {
                    b.HasOne("Flexio.Data.Models.Users.User", "ActualOwner")
                        .WithOne("ActualOwnerDetail")
                        .HasForeignKey("Flexio.Data.Models.Users.UserDetail", "ActualOwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Flexio.Data.Models.Users.User", "Creator")
                        .WithOne("CreatorDetail")
                        .HasForeignKey("Flexio.Data.Models.Users.UserDetail", "CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Flexio.Data.Models.Users.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("Flexio.Data.Models.Users.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ActualOwner");

                    b.Navigation("Creator");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Flexio.Data.Models.Users.User", b =>
                {
                    b.Navigation("ActualOwnerDetail");

                    b.Navigation("CreatorDetail");

                    b.Navigation("UserDetail");
                });
#pragma warning restore 612, 618
        }
    }
}