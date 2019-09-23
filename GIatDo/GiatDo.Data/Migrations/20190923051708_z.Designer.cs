﻿// <auto-generated />
using System;
using GiatDo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiatDo.Data.Migrations
{
    [DbContext(typeof(GiatDoDbContext))]
    [Migration("20190923051708_z")]
    partial class z
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiatDo.Model.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<Guid>("User_Id");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("GiatDo.Model.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateCreate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("GiatDo.Model.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<float>("Rate");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("GiatDo.Model.MyUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Problem");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GiatDo.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<Guid?>("ShipperDeliverId");

                    b.Property<Guid?>("ShipperTakeId");

                    b.Property<Guid?>("SlotDeliveryId");

                    b.Property<Guid?>("SlotTakeId");

                    b.Property<bool>("Status");

                    b.Property<DateTime>("TakeTime");

                    b.Property<float>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShipperDeliverId");

                    b.HasIndex("ShipperTakeId");

                    b.HasIndex("SlotDeliveryId");

                    b.HasIndex("SlotTakeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GiatDo.Model.OrderService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("OrderId");

                    b.Property<string>("Price");

                    b.Property<string>("Quantity");

                    b.Property<Guid?>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderService");
                });

            modelBuilder.Entity("GiatDo.Model.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Price");

                    b.Property<Guid>("ServiceTypeId");

                    b.Property<Guid>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("GiatDo.Model.ServiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ServiceType");
                });

            modelBuilder.Entity("GiatDo.Model.Shipper", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<float>("Rate");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("GiatDo.Model.Slot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.HasKey("Id");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("GiatDo.Model.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<float>("Rate");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GiatDo.Model.Admin", b =>
                {
                    b.HasOne("GiatDo.Model.Account", "Account")
                        .WithOne("Admin")
                        .HasForeignKey("GiatDo.Model.Admin", "AccountId");
                });

            modelBuilder.Entity("GiatDo.Model.Customer", b =>
                {
                    b.HasOne("GiatDo.Model.Account", "Account")
                        .WithOne("Customer")
                        .HasForeignKey("GiatDo.Model.Customer", "AccountId");
                });

            modelBuilder.Entity("GiatDo.Model.Order", b =>
                {
                    b.HasOne("GiatDo.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GiatDo.Model.Shipper", "ShipperDeliver")
                        .WithMany("OrderDelivery")
                        .HasForeignKey("ShipperDeliverId");

                    b.HasOne("GiatDo.Model.Shipper", "ShipperTake")
                        .WithMany("OrderTakes")
                        .HasForeignKey("ShipperTakeId");

                    b.HasOne("GiatDo.Model.Slot", "SlotDelivery")
                        .WithMany("OrdersDelivery")
                        .HasForeignKey("SlotDeliveryId");

                    b.HasOne("GiatDo.Model.Slot", "SlotTake")
                        .WithMany("OrderTake")
                        .HasForeignKey("SlotTakeId");
                });

            modelBuilder.Entity("GiatDo.Model.OrderService", b =>
                {
                    b.HasOne("GiatDo.Model.Order", "Order")
                        .WithMany("OrderServices")
                        .HasForeignKey("OrderId");

                    b.HasOne("GiatDo.Model.Service", "Service")
                        .WithMany("OrderServices")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("GiatDo.Model.Service", b =>
                {
                    b.HasOne("GiatDo.Model.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GiatDo.Model.Store", "Store")
                        .WithMany("Services")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GiatDo.Model.Shipper", b =>
                {
                    b.HasOne("GiatDo.Model.Account", "Account")
                        .WithOne("Shipper")
                        .HasForeignKey("GiatDo.Model.Shipper", "AccountId");
                });

            modelBuilder.Entity("GiatDo.Model.Store", b =>
                {
                    b.HasOne("GiatDo.Model.Account", "Account")
                        .WithOne("Store")
                        .HasForeignKey("GiatDo.Model.Store", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GiatDo.Model.MyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GiatDo.Model.MyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GiatDo.Model.MyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GiatDo.Model.MyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
