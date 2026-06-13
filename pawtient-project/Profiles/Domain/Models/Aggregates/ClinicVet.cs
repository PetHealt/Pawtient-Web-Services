namespace pawtient_project.Profiles.Domain.Models.Aggregates;

public class ClinicVet
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int VeterinarianId { get; private set; }
    public DateOnly? StartDate { get; private set; }
    public string Status { get; private set; }

    // Navegación
    public Clinic? Clinic { get; private set; }
    public Veterinarian? Veterinarian { get; private set; }

    public ClinicVet() { }

    public ClinicVet(int clinicId, int veterinarianId, DateOnly? startDate)
    {
        ClinicId = clinicId;
        VeterinarianId = veterinarianId;
        StartDate = startDate;
        Status = "ACTIVE";
    }
}