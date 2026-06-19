using Microsoft.EntityFrameworkCore;
using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.Profiles.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Appointment.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Models.Aggregates;

namespace pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
        // IAM
    public DbSet<User> Users { get; set; }

    // Profiles
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<Profiles.Domain.Models.Aggregates.Clinic> Clinics { get; set; }
    public DbSet<ClinicVet> ClinicVets { get; set; }

    // Clinic
    public DbSet<Species> Species { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<ConsultationType> ConsultationTypes { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<VitalSign> VitalSigns { get; set; }
    public DbSet<IcdCode> IcdCodes { get; set; }
    public DbSet<Diagnosis> Diagnoses { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    public DbSet<ExamType> ExamTypes { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<PsychRecord> PsychRecords { get; set; }
    public DbSet<Surgery> Surgeries { get; set; }

    // Appointment
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Appointment.Domain.Models.Aggregates.Appointment> Appointments { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<VaccineReminder> VaccineReminders { get; set; }

    // Store
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<InventoryMovement> InventoryMovements { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<StockAlert> StockAlerts { get; set; }

    // Report
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<ConsultationReport> ConsultationReports { get; set; }
    public DbSet<VaccinationReport> VaccinationReports { get; set; }
    public DbSet<InventoryReport> InventoryReports { get; set; }
    public DbSet<AppointmentReport> AppointmentReports { get; set; }

    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
        // =============================================
        // IAM
        // =============================================
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
            entity.Property(e => e.Status).HasColumnName("USU_status").HasMaxLength(20).HasDefaultValue("ACTIVE");
            entity.Property(e => e.CreatedAt).HasColumnName("USU_created_at");
        });

        // =============================================
        // Profiles
        // =============================================
        builder.Entity<Specialization>(entity =>
        {
            entity.ToTable("Specializations");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SPC_id");
            entity.Property(e => e.Name).HasColumnName("SPC_name").IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<Veterinarian>(entity =>
        {
            entity.ToTable("Veterinarians");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("VET_id");
            entity.Property(e => e.UserId).HasColumnName("USU_id").IsRequired();
            entity.HasIndex(e => e.UserId).IsUnique();
            entity.Property(e => e.LicenseNumber).HasColumnName("VET_license_number");
            entity.HasIndex(e => e.LicenseNumber).IsUnique();
            entity.Property(e => e.SpecializationId).HasColumnName("SPC_id");
            entity.HasOne(e => e.Specialization)
                .WithMany()
                .HasForeignKey(e => e.SpecializationId);
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
            entity.HasIndex(e => e.Ruc).IsUnique();
        });

        builder.Entity<ClinicVet>(entity =>
        {
            entity.ToTable("Clinic_vets");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("CLV_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id").IsRequired();
            entity.Property(e => e.StartDate).HasColumnName("CLV_start_date");
            entity.Property(e => e.Status) .HasColumnName("CLV_status") .HasMaxLength(20) .HasDefaultValue("ACTIVE");
            entity.HasIndex(e => new { e.ClinicId, e.VeterinarianId }).IsUnique();
            entity.HasOne(e => e.Clinic).WithMany().HasForeignKey(e => e.ClinicId);
            entity.HasOne(e => e.Veterinarian).WithMany().HasForeignKey(e => e.VeterinarianId);
        });

        // =============================================
        // Clinic
        // =============================================
        builder.Entity<Species>(entity =>
        {
            entity.ToTable("Species");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SPE_id");
            entity.Property(e => e.Name).HasColumnName("SPE_name").IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<Breed>(entity =>
        {
            entity.ToTable("Breeds");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("BRE_id");
            entity.Property(e => e.SpeciesId).HasColumnName("SPE_id").IsRequired();
            entity.Property(e => e.Name).HasColumnName("BRE_name").IsRequired();
            entity.HasIndex(e => new { e.SpeciesId, e.Name }).IsUnique();
            entity.HasOne(e => e.Species).WithMany().HasForeignKey(e => e.SpeciesId);
        });

        builder.Entity<Pet>(entity =>
        {
            entity.ToTable("Pets");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PET_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.SpeciesId).HasColumnName("SPE_id").IsRequired();
            entity.Property(e => e.BreedId).HasColumnName("BRE_id");
            entity.Property(e => e.Name).HasColumnName("PET_name").IsRequired();
            entity.Property(e => e.BirthDate).HasColumnName("PET_birth_date");
            entity.Property(e => e.Sex) .HasColumnName("PET_sex").HasMaxLength(10).HasDefaultValue("UNKNOWN");
            entity.Property(e => e.Microchip).HasColumnName("PET_microchip");
            entity.HasIndex(e => e.Microchip).IsUnique();
            entity.Property(e => e.CoatColor).HasColumnName("PET_coat_color");
            entity.Property(e => e.WeightKg).HasColumnName("PET_weight_kg");
            entity.Property(e => e.IsActive).HasColumnName("PET_is_active").HasDefaultValue(true);
            entity.HasOne(e => e.Species).WithMany().HasForeignKey(e => e.SpeciesId);
            entity.HasOne(e => e.Breed).WithMany().HasForeignKey(e => e.BreedId);
        });

        builder.Entity<MedicalRecord>(entity =>
        {
            entity.ToTable("Medical_records");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("MRC_id");
            entity.Property(e => e.PetId).HasColumnName("PET_id").IsRequired();
            entity.HasIndex(e => e.PetId).IsUnique();
            entity.Property(e => e.CreatedAt).HasColumnName("MRC_created_at");
            entity.Property(e => e.Anamnesis).HasColumnName("MRC_anamnesis");
            entity.HasOne(e => e.Pet).WithMany().HasForeignKey(e => e.PetId);
        });

        builder.Entity<ConsultationType>(entity =>
        {
            entity.ToTable("Consultation_types");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("CNT_id");
            entity.Property(e => e.Name).HasColumnName("CNT_name").IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<Consultation>(entity =>
        {
            entity.ToTable("Consultations");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("CON_id");
            entity.Property(e => e.MedicalRecordId).HasColumnName("MRC_id").IsRequired();
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id").IsRequired();
            entity.Property(e => e.ConsultationTypeId).HasColumnName("CNT_id");
            entity.Property(e => e.Date).HasColumnName("CON_date").IsRequired();
            entity.Property(e => e.Status) .HasColumnName("CON_status") .HasMaxLength(20) .HasDefaultValue("IN_PROGRESS");
            entity.Property(e => e.Notes).HasColumnName("CON_notes");
            entity.HasOne(e => e.MedicalRecord).WithMany().HasForeignKey(e => e.MedicalRecordId);
            entity.HasOne(e => e.ConsultationType).WithMany().HasForeignKey(e => e.ConsultationTypeId);
        });

        builder.Entity<VitalSign>(entity =>
        {
            entity.ToTable("Vital_signs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("VSG_id");
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id").IsRequired();
            entity.Property(e => e.Temperature).HasColumnName("VSG_temperature");
            entity.Property(e => e.Weight).HasColumnName("VSG_weight");
            entity.Property(e => e.HeartRate).HasColumnName("VSG_heart_rate");
            entity.Property(e => e.RespiratoryRate).HasColumnName("VSG_respiratory_rate");
            entity.Property(e => e.PainScale).HasColumnName("VSG_pain_scale");
            entity.Property(e => e.RecordedAt).HasColumnName("VSG_recorded_at");
            entity.HasOne(e => e.Consultation).WithMany().HasForeignKey(e => e.ConsultationId);
        });

        builder.Entity<IcdCode>(entity =>
        {
            entity.ToTable("ICD_codes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ICD_id");
            entity.Property(e => e.Code).HasColumnName("ICD_code").IsRequired();
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.Description).HasColumnName("ICD_description").IsRequired();
        });

        builder.Entity<Diagnosis>(entity =>
        {
            entity.ToTable("Diagnoses");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("DGN_id");
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id").IsRequired();
            entity.Property(e => e.IcdCodeId).HasColumnName("ICD_id");
            entity.Property(e => e.Type).HasColumnName("DGN_type").HasMaxLength(20).HasDefaultValue("PRESUMPTIVE");
            entity.Property(e => e.Notes).HasColumnName("DGN_notes");
            entity.HasOne(e => e.Consultation).WithMany().HasForeignKey(e => e.ConsultationId);
            entity.HasOne(e => e.IcdCode).WithMany().HasForeignKey(e => e.IcdCodeId);
        });

        builder.Entity<Prescription>(entity =>
        {
            entity.ToTable("Prescriptions");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PRE_id");
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id").IsRequired();
            entity.Property(e => e.Instructions).HasColumnName("PRE_instructions");
            entity.Property(e => e.StartDate).HasColumnName("PRE_start_date");
            entity.Property(e => e.EndDate).HasColumnName("PRE_end_date");
            entity.HasOne(e => e.Consultation).WithMany().HasForeignKey(e => e.ConsultationId);
        });

        builder.Entity<PrescriptionItem>(entity =>
        {
            entity.ToTable("Prescription_items");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PRI_id");
            entity.Property(e => e.PrescriptionId).HasColumnName("PRE_id").IsRequired();
            entity.Property(e => e.ProductId).HasColumnName("PRD_id").IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("PRI_quantity").HasDefaultValue(1);
            entity.Property(e => e.Dosage).HasColumnName("PRI_dosage");
            entity.Property(e => e.Frequency).HasColumnName("PRI_frequency");
            entity.Property(e => e.Route).HasColumnName("PRI_route");
            entity.HasOne(e => e.Prescription).WithMany().HasForeignKey(e => e.PrescriptionId);
        });

        builder.Entity<ExamType>(entity =>
        {
            entity.ToTable("Exam_types");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("EXT_id");
            entity.Property(e => e.Name).HasColumnName("EXT_name").IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Category).HasColumnName("EXT_category");
        });

        builder.Entity<Exam>(entity =>
        {
            entity.ToTable("Exams");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("EXM_id");
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id").IsRequired();
            entity.Property(e => e.ExamTypeId).HasColumnName("EXT_id").IsRequired();
            entity.Property(e => e.Result).HasColumnName("EXM_result");
            entity.Property(e => e.Status).HasColumnName("EXM_status").HasMaxLength(20).HasDefaultValue("PENDING");
            entity.Property(e => e.Date).HasColumnName("EXM_date");
            entity.HasOne(e => e.Consultation).WithMany().HasForeignKey(e => e.ConsultationId);
            entity.HasOne(e => e.ExamType).WithMany().HasForeignKey(e => e.ExamTypeId);
        });

        builder.Entity<Vaccine>(entity =>
        {
            entity.ToTable("Vaccines");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("VAC_id");
            entity.Property(e => e.MedicalRecordId).HasColumnName("MRC_id").IsRequired();
            entity.Property(e => e.ProductId).HasColumnName("PRD_id").IsRequired();
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id").IsRequired();
            entity.Property(e => e.Date).HasColumnName("VAC_date").IsRequired();
            entity.Property(e => e.NextDate).HasColumnName("VAC_next_date");
            entity.Property(e => e.BatchNumber).HasColumnName("VAC_batch_number");
            entity.Property(e => e.Status).HasColumnName("VAC_status").HasMaxLength(20).HasDefaultValue("APPLIED");
            entity.HasOne(e => e.MedicalRecord).WithMany().HasForeignKey(e => e.MedicalRecordId);
        });

        builder.Entity<PsychRecord>(entity =>
        {
            entity.ToTable("Psych_records");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PSY_id");
            entity.Property(e => e.MedicalRecordId).HasColumnName("MRC_id").IsRequired();
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id");
            entity.Property(e => e.Behavior).HasColumnName("PSY_behavior");
            entity.Property(e => e.Triggers).HasColumnName("PSY_triggers");
            entity.Property(e => e.Treatment).HasColumnName("PSY_treatment");
            entity.Property(e => e.AnxietyScale).HasColumnName("PSY_anxiety_scale");
            entity.Property(e => e.RecordedAt).HasColumnName("PSY_recorded_at");
            entity.HasOne(e => e.MedicalRecord).WithMany().HasForeignKey(e => e.MedicalRecordId);
        });

        builder.Entity<Surgery>(entity =>
        {
            entity.ToTable("Surgeries");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SUR_id");
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id").IsRequired();
            entity.HasIndex(e => e.ConsultationId).IsUnique();
            entity.Property(e => e.Procedure).HasColumnName("SUR_procedure").IsRequired();
            entity.Property(e => e.DurationMinutes).HasColumnName("SUR_duration_min");
            entity.Property(e => e.Anesthesia).HasColumnName("SUR_anesthesia").HasMaxLength(20).HasDefaultValue("GENERAL");
            entity.Property(e => e.Notes).HasColumnName("SUR_notes");
            entity.Property(e => e.Outcome).HasColumnName("SUR_outcome").HasMaxLength(20).HasDefaultValue("IN_PROGRESS");
            entity.HasOne(e => e.Consultation).WithMany().HasForeignKey(e => e.ConsultationId);
        });

        // =============================================
        // Appointment
        // =============================================
        builder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedules");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SCH_id");
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id").IsRequired();
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.Date).HasColumnName("SCH_date").IsRequired();
            entity.Property(e => e.StartTime).HasColumnName("SCH_start_time").IsRequired();
            entity.Property(e => e.EndTime).HasColumnName("SCH_end_time").IsRequired();
            entity.Property(e => e.IsAvailable).HasColumnName("SCH_is_available").HasDefaultValue(true);
            entity.HasIndex(e => new { e.VeterinarianId, e.ClinicId, e.Date, e.StartTime }).IsUnique();
        });

        builder.Entity<Appointment.Domain.Models.Aggregates.Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("APT_id");
            entity.Property(e => e.PetId).HasColumnName("PET_id").IsRequired();
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id").IsRequired();
            entity.Property(e => e.ScheduleId).HasColumnName("SCH_id");
            entity.Property(e => e.Date).HasColumnName("APT_date").IsRequired();
            entity.Property(e => e.Status).HasColumnName("APT_status").HasMaxLength(20).HasDefaultValue("REQUESTED");
            entity.Property(e => e.Reason).HasColumnName("APT_reason");
            entity.Property(e => e.Type).HasColumnName("APT_type").HasMaxLength(20).HasDefaultValue("FIRST_VISIT");
            entity.Property(e => e.CreatedAt).HasColumnName("APT_created_at");
            entity.HasOne(e => e.Schedule).WithMany().HasForeignKey(e => e.ScheduleId);
        });

        builder.Entity<Reminder>(entity =>
        {
            entity.ToTable("Reminders");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("REM_id");
            entity.Property(e => e.AppointmentId).HasColumnName("APT_id");
            entity.Property(e => e.Message).HasColumnName("REM_message");
            entity.Property(e => e.ScheduledAt).HasColumnName("REM_scheduled_at");
            entity.Property(e => e.SentAt).HasColumnName("REM_sent_at");
            entity.Property(e => e.Channel).HasColumnName("REM_channel").HasMaxLength(20).HasDefaultValue("INTERNAL");
            entity.HasOne(e => e.Appointment).WithMany().HasForeignKey(e => e.AppointmentId);
        });

        builder.Entity<VaccineReminder>(entity =>
        {
            entity.ToTable("Vaccine_reminders");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("VRE_id");
            entity.Property(e => e.VaccineId).HasColumnName("VAC_id").IsRequired();
            entity.Property(e => e.ReminderId).HasColumnName("REM_id").IsRequired();
            entity.HasOne(e => e.Reminder).WithMany().HasForeignKey(e => e.ReminderId);
        });

        // =============================================
        // Store
        // =============================================
        builder.Entity<ProductCategory>(entity => {
            entity.ToTable("Product_categories");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("CAT_id");
            entity.Property(e => e.Name).HasColumnName("CAT_name").IsRequired();
        });

        builder.Entity<Supplier>(entity => {
            entity.ToTable("Suppliers");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SUP_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.Name).HasColumnName("SUP_name").IsRequired();
            entity.Property(e => e.ContactEmail).HasColumnName("SUP_contact_email");
            entity.Property(e => e.Phone).HasColumnName("SUP_phone");
            entity.Property(e => e.Ruc).HasColumnName("SUP_ruc");
        });

        builder.Entity<Product>(entity => {
            entity.ToTable("Products");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PRD_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.CategoryId).HasColumnName("CAT_id");
            entity.Property(e => e.SupplierId).HasColumnName("SUP_id");
            entity.Property(e => e.Name).HasColumnName("PRD_name").IsRequired();
            entity.Property(e => e.Description).HasColumnName("PRD_description");
            entity.Property(e => e.UnitPrice).HasColumnName("PRD_unit_price");
            entity.Property(e => e.Stock).HasColumnName("PRD_stock");
            entity.Property(e => e.MinimumStock).HasColumnName("PRD_minimum_stock");
            entity.Property(e => e.IsActive).HasColumnName("PRD_is_active");
            entity.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
            entity.HasOne(e => e.Supplier).WithMany().HasForeignKey(e => e.SupplierId);
        });

        builder.Entity<InventoryMovement>(entity => {
            entity.ToTable("Inventory_movements");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("IVM_id");
            entity.Property(e => e.ProductId).HasColumnName("PRD_id").IsRequired();
            entity.Property(e => e.Quantity).HasColumnName("IVM_quantity");
            entity.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
        });

        builder.Entity<StockAlert>(entity => {
            entity.ToTable("Stock_alerts");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("SAL_id");
            entity.Property(e => e.ProductId).HasColumnName("PRD_id").IsRequired();
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.Resolved).HasColumnName("SAL_resolved");
            entity.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
        });

        // =============================================
        // Report
        // =============================================
        builder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoices");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("INV_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.AppointmentId).HasColumnName("APT_id");
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id");
            entity.Property(e => e.PetName).HasColumnName("INV_pet_name").IsRequired();
            entity.Property(e => e.OwnerName).HasColumnName("INV_owner_name");
            entity.Property(e => e.Amount).HasColumnName("INV_amount").HasDefaultValue(0.00m);
            entity.Property(e => e.Date).HasColumnName("INV_date");
            entity.Property(e => e.Status) .HasColumnName("INV_status") .HasMaxLength(20) .HasDefaultValue("PENDING");
            entity.Property(e => e.Notes).HasColumnName("INV_notes");
        });

        builder.Entity<ConsultationReport>(entity =>
        {
            entity.ToTable("Consultation_reports");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("CRP_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.ConsultationId).HasColumnName("CON_id").IsRequired();
            entity.Property(e => e.PetId).HasColumnName("PET_id").IsRequired();
            entity.Property(e => e.VeterinarianId).HasColumnName("VET_id").IsRequired();
            entity.Property(e => e.GeneratedAt).HasColumnName("CRP_generated_at");
            entity.Property(e => e.Summary).HasColumnName("CRP_summary").IsRequired();
            entity.Property(e => e.Observations).HasColumnName("CRP_observations");
        });

        builder.Entity<VaccinationReport>(entity =>
        {
            entity.ToTable("Vaccination_reports");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("VRP_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.PetId).HasColumnName("PET_id").IsRequired();
            entity.Property(e => e.VaccineId).HasColumnName("VAC_id").IsRequired();
            entity.Property(e => e.GeneratedAt).HasColumnName("VRP_generated_at");
            entity.Property(e => e.Status).HasColumnName("VRP_status").IsRequired();
            entity.Property(e => e.Notes).HasColumnName("VRP_notes");
        });

        builder.Entity<InventoryReport>(entity =>
        {
            entity.ToTable("Inventory_reports");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("IRP_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.GeneratedAt).HasColumnName("IRP_generated_at");
            entity.Property(e => e.TotalProducts).HasColumnName("IRP_total_products");
            entity.Property(e => e.LowStockCount).HasColumnName("IRP_low_stock_count");
            entity.Property(e => e.TotalInventoryValue).HasColumnName("IRP_total_inventory_value");
            entity.Property(e => e.Notes).HasColumnName("IRP_notes");
        });

        builder.Entity<AppointmentReport>(entity =>
        {
            entity.ToTable("Appointment_reports");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ARP_id");
            entity.Property(e => e.ClinicId).HasColumnName("CLI_id").IsRequired();
            entity.Property(e => e.GeneratedAt).HasColumnName("ARP_generated_at");
            entity.Property(e => e.PeriodStart).HasColumnName("ARP_period_start").IsRequired();
            entity.Property(e => e.PeriodEnd).HasColumnName("ARP_period_end").IsRequired();
            entity.Property(e => e.TotalAppointments).HasColumnName("ARP_total_appointments");
            entity.Property(e => e.CompletedAppointments).HasColumnName("ARP_completed");
            entity.Property(e => e.CancelledAppointments).HasColumnName("ARP_cancelled");
            entity.Property(e => e.NoShowAppointments).HasColumnName("ARP_no_show");
        });
    }
}