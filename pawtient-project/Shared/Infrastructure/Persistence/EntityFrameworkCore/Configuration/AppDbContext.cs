using Microsoft.EntityFrameworkCore;
using pawtient_project.Appointment.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.Profiles.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Profiles.Domain.Models.Aggregates.Clinic> Clinics { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Appointment.Domain.Models.Aggregates.Appointment> Appointments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("USU_id");
            entity.Property(e => e.FullName).HasColumnName("USU_full_name").IsRequired();
            entity.Property(e => e.Email).HasColumnName("USU_email").IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.PasswordHash).HasColumnName("USU_password_hash").IsRequired();
            entity.Property(e => e.Role).HasColumnName("USU_role").IsRequired();
            entity.Property(e => e.PlanName).HasColumnName("USU_plan_name").HasMaxLength(50).HasDefaultValue("Paw Care");
            entity.Property(e => e.Status).HasColumnName("USU_status").HasMaxLength(20).HasDefaultValue("ACTIVE");
            entity.Property(e => e.CreatedAt).HasColumnName("USU_created_at");
        });

        builder.Entity<Profiles.Domain.Models.Aggregates.Clinic>(entity =>
        {
            entity.ToTable("Clinics");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("CLI_id");
            entity.Property(e => e.UserId).HasColumnName("USU_id").IsRequired();
            entity.HasIndex(e => e.UserId).IsUnique();
            entity.Property(e => e.Name).HasColumnName("CLI_name").IsRequired();
            entity.Property(e => e.Address).HasColumnName("CLI_address");
            entity.Property(e => e.Phone).HasColumnName("CLI_phone");
            entity.Property(e => e.Ruc).HasColumnName("CLI_ruc");
        });

        builder.Entity<Pet>(entity =>
        {
            entity.ToTable("Pets");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PET_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.Name).HasColumnName("PET_name").IsRequired();
            entity.Property(e => e.SpeciesName).HasColumnName("PET_species_name").HasMaxLength(100).HasDefaultValue("");
            entity.Property(e => e.BreedName).HasColumnName("PET_breed_name").HasMaxLength(100).HasDefaultValue("");
            entity.Property(e => e.Age).HasColumnName("PET_age").HasDefaultValue(0);
            entity.Property(e => e.BirthDate).HasColumnName("PET_birth_date");
            entity.Property(e => e.Sex).HasColumnName("PET_sex").HasMaxLength(10).HasDefaultValue("UNKNOWN");
            entity.Property(e => e.Microchip).HasColumnName("PET_microchip");
            entity.HasIndex(e => e.Microchip).IsUnique();
            entity.Property(e => e.CoatColor).HasColumnName("PET_coat_color");
            entity.Property(e => e.WeightKg).HasColumnName("PET_weight_kg");
            entity.Property(e => e.IsActive).HasColumnName("PET_is_active").HasDefaultValue(true);
            entity.Ignore(e => e.SpeciesId);
            entity.Ignore(e => e.BreedId);
            entity.Ignore(e => e.Species);
            entity.Ignore(e => e.Breed);
        });

        builder.Entity<Appointment.Domain.Models.Aggregates.Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("APT_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id");
            entity.Property(e => e.PetId).HasColumnName("PET_id");
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id");
            entity.Property(e => e.Date).HasColumnName("APT_date").IsRequired();
            entity.Property(e => e.Time).HasColumnName("APT_time").HasMaxLength(10).HasDefaultValue("");
            entity.Property(e => e.Patient).HasColumnName("APT_patient").HasMaxLength(150).HasDefaultValue("");
            entity.Property(e => e.Owner).HasColumnName("APT_owner").HasMaxLength(150).HasDefaultValue("");
            entity.Property(e => e.Status).HasColumnName("APT_status").HasMaxLength(20).HasDefaultValue("REQUESTED");
            entity.Property(e => e.Reason).HasColumnName("APT_reason");
            entity.Property(e => e.Type).HasColumnName("APT_type").HasMaxLength(20).HasDefaultValue("FIRST_VISIT");
            entity.Property(e => e.Amount).HasColumnName("APT_amount").HasDefaultValue(0.00m);
            entity.Property(e => e.CreatedAt).HasColumnName("APT_created_at");
            entity.Ignore(e => e.ScheduleId);
            entity.Ignore(e => e.Schedule);
        });

        builder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PRD_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.SupplierId).HasColumnName("SUP_id");
            entity.Property(e => e.Name).HasColumnName("PRD_name").IsRequired();
            entity.Property(e => e.Description).HasColumnName("PRD_description");
            entity.Property(e => e.UnitPrice).HasColumnName("PRD_unit_price").HasPrecision(18, 2);
            entity.Property(e => e.Stock).HasColumnName("PRD_stock");
            entity.Property(e => e.MinimumStock).HasColumnName("PRD_minimum_stock");
            entity.Property(e => e.IsActive).HasColumnName("PRD_is_active");
            entity.HasOne(e => e.Supplier).WithMany().HasForeignKey(e => e.SupplierId);
            entity.Ignore(e => e.CategoryId);
            entity.Ignore(e => e.Category);
        });

        builder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Suppliers");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SUP_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.Name).HasColumnName("SUP_name").IsRequired();
            entity.Property(e => e.ContactEmail).HasColumnName("SUP_contact_email");
            entity.Property(e => e.Phone).HasColumnName("SUP_phone");
            entity.Property(e => e.Ruc).HasColumnName("SUP_ruc");
            entity.Property(e => e.Contact).HasColumnName("SUP_contact");
            entity.Property(e => e.Category).HasColumnName("SUP_category");
        });

        builder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoices");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("INV_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.AppointmentId).HasColumnName("APT_id");
            entity.Property(e => e.PetName).HasColumnName("INV_pet_name").IsRequired();
            entity.Property(e => e.OwnerName).HasColumnName("INV_owner_name");
            entity.Property(e => e.Patient).HasColumnName("INV_patient");
            entity.Property(e => e.Client).HasColumnName("INV_client");
            entity.Property(e => e.Amount).HasColumnName("INV_amount").HasPrecision(18, 2).HasDefaultValue(0.00m);
            entity.Property(e => e.Date).HasColumnName("INV_date");
            entity.Property(e => e.Status).HasColumnName("INV_status").HasMaxLength(20).HasDefaultValue("PENDING");
            entity.Property(e => e.Notes).HasColumnName("INV_notes");
            entity.Ignore(e => e.ConsultationId);
        });
    }
}
