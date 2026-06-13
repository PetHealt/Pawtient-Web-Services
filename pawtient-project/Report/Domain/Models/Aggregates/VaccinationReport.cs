namespace pawtient_project.Report.Domain.Models.Aggregates;


public class VaccinationReport
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int PetId { get; private set; }
    public int VaccineId { get; private set; }
    public DateTime GeneratedAt { get; private set; }
    public string Status { get; private set; }
    public string? Notes { get; private set; }

    public VaccinationReport() { }

    public VaccinationReport(int clinicId, int petId, int vaccineId,
        string status, string? notes)
    {
        ClinicId = clinicId;
        PetId = petId;
        VaccineId = vaccineId;
        Status = status;
        Notes = notes;
        GeneratedAt = DateTime.UtcNow;
    }
}