using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBContext.Models;

#nullable disable

namespace DBContext.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionAudit> ActionAudits { get; set; }
        public virtual DbSet<Authentication> Authentications { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarEvent> CarEvents { get; set; }
        public virtual DbSet<CarService> CarServices { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PhotoArchive> PhotoArchives { get; set; }
        public virtual DbSet<PhotoPhotoArchive> PhotoPhotoArchives { get; set; }
        public virtual DbSet<Refill> Refills { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersCar> UsersCars { get; set; }
        public virtual DbSet<UsersCarsRight> UsersCarsRights { get; set; }
        public virtual DbSet<UsersCarsRole> UsersCarsRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-V2B67VR\\VITALISQL;Database=MiCarDrive;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ActionAudit>(entity =>
            {
                entity.HasKey(e => new { e.EntityId, e.DateUpdate, e.UserId })
                    .HasName("PK_ACTIONAUDIT");

                entity.ToTable("ACTION_AUDIT");

                entity.Property(e => e.EntityId).HasColumnName("ENTITY_ID");

                entity.Property(e => e.DateUpdate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DATE_UPDATE");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActionAudits)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACTIONAUDIT_USER");
            });

            modelBuilder.Entity<Authentication>(entity =>
            {
                entity.HasKey(e => e.Login);

                entity.ToTable("AUTHENTICATION");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("LOGIN");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Authentications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHENTICATION_USER");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CARS");

                entity.HasIndex(e => e.Vin, "UQ__CARS__C5DF234C42AA39B9")
                    .IsUnique();

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Comment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.FuelTypeId).HasColumnName("FUEL_TYPE_ID");

                entity.Property(e => e.Mark)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARK");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.PhotoArchiveId).HasColumnName("PHOTO_ARCHIVE_ID");

                entity.Property(e => e.Power).HasColumnName("POWER");

                entity.Property(e => e.TransmissionTypeId).HasColumnName("TRANSMISSION_TYPE_ID");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.Property(e => e.VolumeEngine).HasColumnName("VOLUME_ENGINE");

                entity.Property(e => e.YearIssue).HasColumnName("YEAR_ISSUE");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARS_FUELTYPE");

                entity.HasOne(d => d.PhotoArchive)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.PhotoArchiveId)
                    .HasConstraintName("FK_CARS_PHOTOARCHIVE");

                entity.HasOne(d => d.TransmissionType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.TransmissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CARS_TRANSMISSIONTYPE");
            });

            modelBuilder.Entity<CarEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK_EVENTS");

                entity.ToTable("CAR_EVENTS");

                entity.Property(e => e.EventId)
                    .HasColumnName("EVENT_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressStation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_STATION");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Costs)
                    .HasColumnType("money")
                    .HasColumnName("COSTS");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("DATE");

                entity.Property(e => e.EventTypeId).HasColumnName("EVENT_TYPE_ID");

                entity.Property(e => e.Mileage).HasColumnName("MILEAGE");

                entity.Property(e => e.PhotoArchiveId).HasColumnName("PHOTO_ARCHIVE_ID");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("UNIT_PRICE");

                entity.Property(e => e.UserCarId).HasColumnName("USER_CAR_ID");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.CarEvents)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVENTS_TYPEEVENTS");

                entity.HasOne(d => d.PhotoArchive)
                    .WithMany(p => p.CarEvents)
                    .HasForeignKey(d => d.PhotoArchiveId)
                    .HasConstraintName("FK_EVENTS_PHOTOARCHIVE");

                entity.HasOne(d => d.UserCar)
                    .WithMany(p => p.CarEvents)
                    .HasForeignKey(d => d.UserCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EVENTS_USERSCARS");
            });

            modelBuilder.Entity<CarService>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK_SERVICE");

                entity.ToTable("CAR_SERVICES");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("SERVICE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EventId).HasColumnName("EVENT_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.TypeServiceId).HasColumnName("TYPE_SERVICE_ID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.CarServices)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_SERVICES_EVENTS");

                entity.HasOne(d => d.TypeService)
                    .WithMany(p => p.CarServices)
                    .HasForeignKey(d => d.TypeServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICES_TYPESERVICES");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.ToTable("DETAILS");

                entity.Property(e => e.DetailId)
                    .HasColumnName("DETAIL_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CarId).HasColumnName("CAR_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.ServiceId).HasColumnName("SERVICE_ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETAILS_CARS");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_DETAILS_SERVICE");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EVENT_TYPES");

                entity.HasIndex(e => e.Name, "UQ__EVENT_TY__D9C1FA00C38D47B7")
                    .IsUnique();

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("EVENT_TYPE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.ToTable("FUEL_TYPES");

                entity.HasIndex(e => e.Name, "UQ__FUEL_TYP__D9C1FA0073A5024B")
                    .IsUnique();

                entity.Property(e => e.FuelTypeId)
                    .HasColumnName("FUEL_TYPE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("PHOTO");

                entity.Property(e => e.PhotoId)
                    .HasColumnName("PHOTO_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Expansion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EXPANSION");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<PhotoArchive>(entity =>
            {
                entity.ToTable("PHOTO_ARCHIVE");

                entity.HasIndex(e => e.Path, "UQ__PHOTO_AR__5985D08DF3D30FB3")
                    .IsUnique();

                entity.Property(e => e.PhotoArchiveId)
                    .HasColumnName("PHOTO_ARCHIVE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PATH");
            });

            modelBuilder.Entity<PhotoPhotoArchive>(entity =>
            {
                entity.HasKey(e => new { e.PhotoArchiveId, e.PhotoId })
                    .HasName("PK_PHOTO_PHOTOARCHIVE");

                entity.ToTable("PHOTO_PHOTO_ARCHIVE");

                entity.Property(e => e.PhotoArchiveId).HasColumnName("PHOTO_ARCHIVE_ID");

                entity.Property(e => e.PhotoId).HasColumnName("PHOTO_ID");

                entity.HasOne(d => d.PhotoArchive)
                    .WithMany(p => p.PhotoPhotoArchives)
                    .HasForeignKey(d => d.PhotoArchiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHOTO_PHOTOARCHIVE_PHOTO");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.PhotoPhotoArchives)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHOTO_PHOTOARCHIVE_PHOTOARCHIVE");
            });

            modelBuilder.Entity<Refill>(entity =>
            {
                entity.ToTable("REFILL");

                entity.Property(e => e.RefillId)
                    .HasColumnName("REFILL_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EventId).HasColumnName("EVENT_ID");

                entity.Property(e => e.Volume).HasColumnName("VOLUME");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Refills)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_REFILL_EVENTS");
            });

            modelBuilder.Entity<Right>(entity =>
            {
                entity.ToTable("RIGHTS");

                entity.HasIndex(e => e.Name, "UQ__RIGHTS__D9C1FA00F640D36A")
                    .IsUnique();

                entity.Property(e => e.RightId)
                    .HasColumnName("RIGHT_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.HasIndex(e => e.Name, "UQ__ROLES__D9C1FA00A09C0DDE")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnName("ROLE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("SERVICE_TYPES");

                entity.HasIndex(e => e.Name, "UQ__SERVICE___D9C1FA0079BFFBFF")
                    .IsUnique();

                entity.Property(e => e.ServiceTypeId)
                    .HasColumnName("SERVICE_TYPE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<TransmissionType>(entity =>
            {
                entity.ToTable("TRANSMISSION_TYPES");

                entity.HasIndex(e => e.Name, "UQ__TRANSMIS__D9C1FA00560522F4")
                    .IsUnique();

                entity.Property(e => e.TransmissionTypeId)
                    .HasColumnName("TRANSMISSION_TYPE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CITY");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("NAME");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("PATRONYMIC");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE");

                entity.Property(e => e.PhotoArchiveId).HasColumnName("PHOTO_ARCHIVE_ID");

                entity.HasOne(d => d.PhotoArchive)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PhotoArchiveId)
                    .HasConstraintName("FK_USERS_PHOTOARCHIVE");
            });

            modelBuilder.Entity<UsersCar>(entity =>
            {
                entity.HasKey(e => e.UserCarId)
                    .HasName("PK_USERSCARS");

                entity.ToTable("USERS_CARS");

                entity.Property(e => e.UserCarId)
                    .HasColumnName("USER_CAR_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CarId).HasColumnName("CAR_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.UsersCars)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERCARS_CAR");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersCars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERCARS_USER");
            });

            modelBuilder.Entity<UsersCarsRight>(entity =>
            {
                entity.HasKey(e => new { e.UserCarId, e.RightId })
                    .HasName("PK_USERSCARS_RIGHTS");

                entity.ToTable("USERS_CARS_RIGHTS");

                entity.Property(e => e.UserCarId).HasColumnName("USER_CAR_ID");

                entity.Property(e => e.RightId).HasColumnName("RIGHT_ID");

                entity.HasOne(d => d.Right)
                    .WithMany(p => p.UsersCarsRights)
                    .HasForeignKey(d => d.RightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSCARS_RIGHTS_RIGHT");

                entity.HasOne(d => d.UserCar)
                    .WithMany(p => p.UsersCarsRights)
                    .HasForeignKey(d => d.UserCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSCARS_RIGHTS_USER");
            });

            modelBuilder.Entity<UsersCarsRole>(entity =>
            {
                entity.HasKey(e => new { e.UserCarId, e.RoleId })
                    .HasName("PK_USERSCARS_ROLES");

                entity.ToTable("USERS_CARS_ROLES");

                entity.Property(e => e.UserCarId).HasColumnName("USER_CAR_ID");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersCarsRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSCARS_ROLES_ROLE");

                entity.HasOne(d => d.UserCar)
                    .WithMany(p => p.UsersCarsRoles)
                    .HasForeignKey(d => d.UserCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSCARS_ROLES_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
