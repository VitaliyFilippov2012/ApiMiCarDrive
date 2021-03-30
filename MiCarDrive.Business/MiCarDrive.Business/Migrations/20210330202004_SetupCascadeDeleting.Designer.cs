﻿// <auto-generated />
using System;
using DBContext.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBContext.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210330202004_SetupCascadeDeleting")]
    partial class SetupCascadeDeleting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBContext.Models.ActionAudit", b =>
                {
                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ENTITY_ID");

                    b.Property<string>("DateUpdate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DATE_UPDATE");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ACTION");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ENTITY");

                    b.HasKey("EntityId", "DateUpdate", "UserId")
                        .HasName("PK_ACTIONAUDIT");

                    b.HasIndex("UserId");

                    b.ToTable("ACTION_AUDIT");
                });

            modelBuilder.Entity("DBContext.Models.Authentication", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LOGIN");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("PASSWORD");

                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("Login");

                    b.HasIndex("UserId");

                    b.ToTable("AUTHENTICATION");
                });

            modelBuilder.Entity("DBContext.Models.Car", b =>
                {
                    b.Property<Guid>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CAR_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("ACTIVE")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Comment")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("COMMENT");

                    b.Property<Guid>("FuelTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FUEL_TYPE_ID");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("MARK");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("MODEL");

                    b.Property<Guid?>("PhotoArchiveId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ARCHIVE_ID");

                    b.Property<int>("Power")
                        .HasColumnType("int")
                        .HasColumnName("POWER");

                    b.Property<Guid>("TransmissionTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TRANSMISSION_TYPE_ID");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("varchar(17)")
                        .HasColumnName("VIN");

                    b.Property<int>("VolumeEngine")
                        .HasColumnType("int")
                        .HasColumnName("VOLUME_ENGINE");

                    b.Property<int>("YearIssue")
                        .HasColumnType("int")
                        .HasColumnName("YEAR_ISSUE");

                    b.HasKey("CarId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("PhotoArchiveId");

                    b.HasIndex("TransmissionTypeId");

                    b.HasIndex(new[] { "Vin" }, "UQ__CARS__C5DF234C42AA39B9")
                        .IsUnique();

                    b.ToTable("CARS");
                });

            modelBuilder.Entity("DBContext.Models.CarEvent", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EVENT_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("AddressStation")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ADDRESS_STATION");

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("COMMENT");

                    b.Property<decimal>("Costs")
                        .HasColumnType("money")
                        .HasColumnName("COSTS");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnName("DATE");

                    b.Property<Guid>("EventTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EVENT_TYPE_ID");

                    b.Property<long?>("Mileage")
                        .HasColumnType("bigint")
                        .HasColumnName("MILEAGE");

                    b.Property<Guid?>("PhotoArchiveId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ARCHIVE_ID");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("money")
                        .HasColumnName("UNIT_PRICE");

                    b.Property<Guid>("UserCarId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_CAR_ID");

                    b.HasKey("EventId")
                        .HasName("PK_EVENTS");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("PhotoArchiveId");

                    b.HasIndex("UserCarId");

                    b.ToTable("CAR_EVENTS");
                });

            modelBuilder.Entity("DBContext.Models.CarService", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SERVICE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EVENT_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("ServiceTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TYPE_SERVICE_ID");

                    b.HasKey("ServiceId")
                        .HasName("PK_SERVICE");

                    b.HasIndex("EventId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("CAR_SERVICES");
                });

            modelBuilder.Entity("DBContext.Models.Detail", b =>
                {
                    b.Property<Guid>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DETAIL_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CAR_ID");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SERVICE_ID");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TYPE");

                    b.HasKey("DetailId");

                    b.HasIndex("CarId");

                    b.HasIndex("ServiceId");

                    b.ToTable("DETAILS");
                });

            modelBuilder.Entity("DBContext.Models.EventType", b =>
                {
                    b.Property<Guid>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EVENT_TYPE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("EventTypeId");

                    b.HasIndex(new[] { "Name" }, "UQ__EVENT_TY__D9C1FA00C38D47B7")
                        .IsUnique();

                    b.ToTable("EVENT_TYPES");
                });

            modelBuilder.Entity("DBContext.Models.FuelType", b =>
                {
                    b.Property<Guid>("FuelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FUEL_TYPE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("FuelTypeId");

                    b.HasIndex(new[] { "Name" }, "UQ__FUEL_TYP__D9C1FA0073A5024B")
                        .IsUnique();

                    b.ToTable("FUEL_TYPES");
                });

            modelBuilder.Entity("DBContext.Models.Photo", b =>
                {
                    b.Property<Guid>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Expansion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("EXPANSION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("PhotoId");

                    b.ToTable("PHOTO");
                });

            modelBuilder.Entity("DBContext.Models.PhotoArchive", b =>
                {
                    b.Property<Guid>("PhotoArchiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ARCHIVE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("PATH");

                    b.HasKey("PhotoArchiveId");

                    b.HasIndex(new[] { "Path" }, "UQ__PHOTO_AR__5985D08DF3D30FB3")
                        .IsUnique();

                    b.ToTable("PHOTO_ARCHIVE");
                });

            modelBuilder.Entity("DBContext.Models.PhotoPhotoArchive", b =>
                {
                    b.Property<Guid>("PhotoArchiveId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ARCHIVE_ID");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ID");

                    b.HasKey("PhotoArchiveId", "PhotoId")
                        .HasName("PK_PHOTO_PHOTOARCHIVE");

                    b.HasIndex("PhotoId");

                    b.ToTable("PHOTO_PHOTO_ARCHIVE");
                });

            modelBuilder.Entity("DBContext.Models.Refill", b =>
                {
                    b.Property<Guid>("RefillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("REFILL_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EVENT_ID");

                    b.Property<float>("Volume")
                        .HasColumnType("real")
                        .HasColumnName("VOLUME");

                    b.HasKey("RefillId");

                    b.HasIndex("EventId");

                    b.ToTable("REFILL");
                });

            modelBuilder.Entity("DBContext.Models.Right", b =>
                {
                    b.Property<Guid>("RightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RIGHT_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("RightId");

                    b.HasIndex(new[] { "Name" }, "UQ__RIGHTS__D9C1FA00F640D36A")
                        .IsUnique();

                    b.ToTable("RIGHTS");
                });

            modelBuilder.Entity("DBContext.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ROLE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("RoleId");

                    b.HasIndex(new[] { "Name" }, "UQ__ROLES__D9C1FA00A09C0DDE")
                        .IsUnique();

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("DBContext.Models.ServiceType", b =>
                {
                    b.Property<Guid>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SERVICE_TYPE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NAME");

                    b.HasKey("ServiceTypeId");

                    b.HasIndex(new[] { "Name" }, "UQ__SERVICE___D9C1FA0079BFFBFF")
                        .IsUnique();

                    b.ToTable("SERVICE_TYPES");
                });

            modelBuilder.Entity("DBContext.Models.TransmissionType", b =>
                {
                    b.Property<Guid>("TransmissionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TRANSMISSION_TYPE_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("TransmissionTypeId");

                    b.HasIndex(new[] { "Name" }, "UQ__TRANSMIS__D9C1FA00560522F4")
                        .IsUnique();

                    b.ToTable("TRANSMISSION_TYPES");
                });

            modelBuilder.Entity("DBContext.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("BIRTHDAY");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CITY");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("GENDER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("LASTNAME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NAME");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("PATRONYMIC");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PHONE");

                    b.Property<Guid?>("PhotoArchiveId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PHOTO_ARCHIVE_ID");

                    b.HasKey("UserId");

                    b.HasIndex("PhotoArchiveId");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("DBContext.Models.UsersCar", b =>
                {
                    b.Property<Guid>("UserCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_CAR_ID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CAR_ID");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID");

                    b.HasKey("UserCarId")
                        .HasName("PK_USERSCARS");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("USERS_CARS");
                });

            modelBuilder.Entity("DBContext.Models.UsersCarsRight", b =>
                {
                    b.Property<Guid>("UserCarId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_CAR_ID");

                    b.Property<Guid>("RightId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RIGHT_ID");

                    b.HasKey("UserCarId", "RightId")
                        .HasName("PK_USERSCARS_RIGHTS");

                    b.HasIndex("RightId");

                    b.ToTable("USERS_CARS_RIGHTS");
                });

            modelBuilder.Entity("DBContext.Models.UsersCarsRole", b =>
                {
                    b.Property<Guid>("UserCarId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_CAR_ID");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("UserCarId", "RoleId")
                        .HasName("PK_USERSCARS_ROLES");

                    b.HasIndex("RoleId");

                    b.ToTable("USERS_CARS_ROLES");
                });

            modelBuilder.Entity("DBContext.Models.ActionAudit", b =>
                {
                    b.HasOne("DBContext.Models.User", "User")
                        .WithMany("ActionAudits")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ACTIONAUDIT_USER")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBContext.Models.Authentication", b =>
                {
                    b.HasOne("DBContext.Models.User", "User")
                        .WithMany("Authentications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AUTHENTICATION_USER")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBContext.Models.Car", b =>
                {
                    b.HasOne("DBContext.Models.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId")
                        .HasConstraintName("FK_CARS_FUELTYPE")
                        .IsRequired();

                    b.HasOne("DBContext.Models.PhotoArchive", "PhotoArchive")
                        .WithMany("Cars")
                        .HasForeignKey("PhotoArchiveId")
                        .HasConstraintName("FK_CARS_PHOTOARCHIVE");

                    b.HasOne("DBContext.Models.TransmissionType", "TransmissionType")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionTypeId")
                        .HasConstraintName("FK_CARS_TRANSMISSIONTYPE")
                        .IsRequired();

                    b.Navigation("FuelType");

                    b.Navigation("PhotoArchive");

                    b.Navigation("TransmissionType");
                });

            modelBuilder.Entity("DBContext.Models.CarEvent", b =>
                {
                    b.HasOne("DBContext.Models.EventType", "EventType")
                        .WithMany("CarEvents")
                        .HasForeignKey("EventTypeId")
                        .HasConstraintName("FK_EVENTS_TYPEEVENTS")
                        .IsRequired();

                    b.HasOne("DBContext.Models.PhotoArchive", "PhotoArchive")
                        .WithMany("CarEvents")
                        .HasForeignKey("PhotoArchiveId")
                        .HasConstraintName("FK_EVENTS_PHOTOARCHIVE");

                    b.HasOne("DBContext.Models.UsersCar", "UserCar")
                        .WithMany("CarEvents")
                        .HasForeignKey("UserCarId")
                        .HasConstraintName("FK_EVENTS_USERSCARS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("PhotoArchive");

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("DBContext.Models.CarService", b =>
                {
                    b.HasOne("DBContext.Models.CarEvent", "Event")
                        .WithMany("CarServices")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_SERVICES_EVENTS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBContext.Models.ServiceType", "TypeService")
                        .WithMany("CarServices")
                        .HasForeignKey("ServiceTypeId")
                        .HasConstraintName("FK_SERVICES_TYPESERVICES")
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("TypeService");
                });

            modelBuilder.Entity("DBContext.Models.Detail", b =>
                {
                    b.HasOne("DBContext.Models.Car", "Car")
                        .WithMany("Details")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_DETAILS_CARS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBContext.Models.CarService", "Service")
                        .WithMany("Details")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_DETAILS_SERVICE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DBContext.Models.PhotoPhotoArchive", b =>
                {
                    b.HasOne("DBContext.Models.PhotoArchive", "PhotoArchive")
                        .WithMany("PhotoPhotoArchives")
                        .HasForeignKey("PhotoArchiveId")
                        .HasConstraintName("FK_PHOTO_PHOTOARCHIVE_PHOTO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBContext.Models.Photo", "Photo")
                        .WithMany("PhotoPhotoArchives")
                        .HasForeignKey("PhotoId")
                        .HasConstraintName("FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("PhotoArchive");
                });

            modelBuilder.Entity("DBContext.Models.Refill", b =>
                {
                    b.HasOne("DBContext.Models.CarEvent", "Event")
                        .WithMany("Refills")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_REFILL_EVENTS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("DBContext.Models.User", b =>
                {
                    b.HasOne("DBContext.Models.PhotoArchive", "PhotoArchive")
                        .WithMany("Users")
                        .HasForeignKey("PhotoArchiveId")
                        .HasConstraintName("FK_USERS_PHOTOARCHIVE");

                    b.Navigation("PhotoArchive");
                });

            modelBuilder.Entity("DBContext.Models.UsersCar", b =>
                {
                    b.HasOne("DBContext.Models.Car", "Car")
                        .WithMany("UsersCars")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_USERCARS_CAR")
                        .IsRequired();

                    b.HasOne("DBContext.Models.User", "User")
                        .WithMany("UsersCars")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_USERCARS_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBContext.Models.UsersCarsRight", b =>
                {
                    b.HasOne("DBContext.Models.Right", "Right")
                        .WithMany("UsersCarsRights")
                        .HasForeignKey("RightId")
                        .HasConstraintName("FK_USERSCARS_RIGHTS_RIGHT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBContext.Models.UsersCar", "UserCar")
                        .WithMany("UsersCarsRights")
                        .HasForeignKey("UserCarId")
                        .HasConstraintName("FK_USERSCARS_RIGHTS_USER")
                        .IsRequired();

                    b.Navigation("Right");

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("DBContext.Models.UsersCarsRole", b =>
                {
                    b.HasOne("DBContext.Models.Role", "Role")
                        .WithMany("UsersCarsRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_USERSCARS_ROLES_ROLE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBContext.Models.UsersCar", "UserCar")
                        .WithMany("UsersCarsRoles")
                        .HasForeignKey("UserCarId")
                        .HasConstraintName("FK_USERSCARS_ROLES_USER")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("DBContext.Models.Car", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("UsersCars");
                });

            modelBuilder.Entity("DBContext.Models.CarEvent", b =>
                {
                    b.Navigation("CarServices");

                    b.Navigation("Refills");
                });

            modelBuilder.Entity("DBContext.Models.CarService", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("DBContext.Models.EventType", b =>
                {
                    b.Navigation("CarEvents");
                });

            modelBuilder.Entity("DBContext.Models.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("DBContext.Models.Photo", b =>
                {
                    b.Navigation("PhotoPhotoArchives");
                });

            modelBuilder.Entity("DBContext.Models.PhotoArchive", b =>
                {
                    b.Navigation("CarEvents");

                    b.Navigation("Cars");

                    b.Navigation("PhotoPhotoArchives");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DBContext.Models.Right", b =>
                {
                    b.Navigation("UsersCarsRights");
                });

            modelBuilder.Entity("DBContext.Models.Role", b =>
                {
                    b.Navigation("UsersCarsRoles");
                });

            modelBuilder.Entity("DBContext.Models.ServiceType", b =>
                {
                    b.Navigation("CarServices");
                });

            modelBuilder.Entity("DBContext.Models.TransmissionType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("DBContext.Models.User", b =>
                {
                    b.Navigation("ActionAudits");

                    b.Navigation("Authentications");

                    b.Navigation("UsersCars");
                });

            modelBuilder.Entity("DBContext.Models.UsersCar", b =>
                {
                    b.Navigation("CarEvents");

                    b.Navigation("UsersCarsRights");

                    b.Navigation("UsersCarsRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
