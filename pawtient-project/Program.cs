using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
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
using pawtient_project.IAM.Application.CommandServices;
using pawtient_project.IAM.Application.QueryServices;
using pawtient_project.IAM.Application.Internal.CommandServices;
using pawtient_project.IAM.Application.Internal.OutboundServices;
using pawtient_project.IAM.Application.Internal.QueryServices;
using pawtient_project.IAM.Infrastructure.Hashing.BCrypt;
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
using pawtient_project.Store.Application.CommandServices;
using pawtient_project.Store.Application.QueryServices;
using pawtient_project.Store.Application.Internal.CommandServices;
using pawtient_project.Store.Application.Internal.QueryServices;
using pawtient_project.Store.Infrastructure.Persistence.Repositories;
using pawtient_project.Report.Application.Internal.CommandServices;
using pawtient_project.Report.Application.Internal.QueryServices;
using pawtient_project.IAM.Infrastructure.Tokens.Jwt;
using pawtient_project.Shared.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("PawtientFrontend", policy =>
        policy.WithOrigins(
                "http://localhost:5173",
                "http://localhost:4200",
                "https://pawtient.netlify.app")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando el esquema Bearer.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

var tokenSettings = builder.Configuration.GetSection("TokenSettings").Get<TokenSettings>() ?? new TokenSettings();
tokenSettings.Secret = Environment.ExpandEnvironmentVariables(tokenSettings.Secret);
builder.Services.Configure<TokenSettings>(options =>
{
    options.Secret = tokenSettings.Secret;
    options.ExpirationDays = tokenSettings.ExpirationDays;
});
var tokenSecret = tokenSettings.Secret;
if (string.IsNullOrWhiteSpace(tokenSecret) || tokenSecret.Contains('%'))
{
    throw new InvalidOperationException("TokenSettings:Secret is required.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

var connectionString = Environment.ExpandEnvironmentVariables(builder.Configuration.GetConnectionString("DefaultConnection")!);
if (string.IsNullOrWhiteSpace(connectionString) || connectionString.Contains('%'))
{
    throw new InvalidOperationException("ConnectionStrings:DefaultConnection is required.");
}
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString));

// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// IAM
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

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
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IInventoryMovementRepository, InventoryMovementRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IStockAlertRepository, StockAlertRepository>();

builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<ISupplierCommandService, SupplierCommandService>();
builder.Services.AddScoped<ISupplierQueryService, SupplierQueryService>();


// Report
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IConsultationReportRepository, ConsultationReportRepository>();
builder.Services.AddScoped<IInventoryReportRepository, InventoryReportRepository>();
builder.Services.AddScoped<IAppointmentReportRepository, AppointmentReportRepository>();
builder.Services.AddScoped<IVaccinationReportRepository, VaccinationReportRepository>();
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();
builder.Services.AddScoped<IReportQueryService, ReportQueryService>();


var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            status = 500,
            message = "Ocurrió un error interno.",
            errorCode = "INTERNAL_SERVER_ERROR"
        });
    });
});

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

app.UseCors("PawtientFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
