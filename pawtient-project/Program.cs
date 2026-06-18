using Microsoft.EntityFrameworkCore;
using pawtient_project.Appointment.Domain.Repositories;
using pawtient_project.Appointment.Infrastructure.Persistence.Repositories;
using pawtient_project.Clinic.Application.CommandServices;
using pawtient_project.Clinic.Application.Internal.CommandServices;
using pawtient_project.Clinic.Application.Internal.QueryServices;
using pawtient_project.Clinic.Application.QueryServices;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Clinic.Infrastructure.Persistence.Repositories;
using pawtient_project.IAM.Domain.Repositories;
using pawtient_project.IAM.Infrastructure.Persistence.Repositories;
using pawtient_project.Profiles.Domain.Repositories;
using pawtient_project.Profiles.Infrastructure.Persistence.Repositories;
using pawtient_project.Report.Application.CommandServices;
using pawtient_project.Report.Application.QueryServices;
using pawtient_project.Report.Domain.Repositories;
using pawtient_project.Report.Infrastructure.Persistence.Repositories;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using pawtient_project.Store.Domain.Repositories;
using pawtient_project.Store.Infrastructure.Persistence.Repositories;
using pawtient_project.Report.Application.Internal.CommandServices;
using pawtient_project.Report.Application.Internal.QueryServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString!));

// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// IAM
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Profiles
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();

// Clinic
builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
builder.Services.AddScoped<IBreedRepository, BreedRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IPetCommandService, PetCommandService>();
builder.Services.AddScoped<IPetQueryService, PetQueryService>();

// Appointment
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IReminderRepository, ReminderRepository>();

// Store
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInventoryMovementRepository, InventoryMovementRepository>();
builder.Services.AddScoped<IStockAlertRepository, StockAlertRepository>();

// Report
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IConsultationReportRepository, ConsultationReportRepository>();
builder.Services.AddScoped<IInventoryReportRepository, InventoryReportRepository>();
builder.Services.AddScoped<IAppointmentReportRepository, AppointmentReportRepository>();
builder.Services.AddScoped<IVaccinationReportRepository, VaccinationReportRepository>();
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();
builder.Services.AddScoped<IReportQueryService, ReportQueryService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();