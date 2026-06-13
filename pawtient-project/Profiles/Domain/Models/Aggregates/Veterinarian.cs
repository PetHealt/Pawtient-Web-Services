namespace pawtient_project.Profiles.Domain.Models.Aggregates;

public class Veterinarian
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string? LicenseNumber { get; private set; }
    public int? SpecializationId { get; private set; }

    // Navegación
    public Specialization? Specialization { get; private set; }

    public Veterinarian() { }

    public Veterinarian(int userId, string? licenseNumber, int? specializationId)
    {
        UserId = userId;
        LicenseNumber = licenseNumber;
        SpecializationId = specializationId;
    }
}