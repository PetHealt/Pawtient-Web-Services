namespace pawtient_project.Report.Domain.Models.Aggregates;

public class ConsultationReport
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int ConsultationId { get; private set; }
    public int PetId { get; private set; }
    public int VeterinarianId { get; private set; }
    public DateTime GeneratedAt { get; private set; }
    public string Summary { get; private set; }
    public string? Observations { get; private set; }

    public ConsultationReport() { }

    public ConsultationReport(int clinicId, int consultationId, int petId,
        int veterinarianId, string summary, string? observations)
    {
        ClinicId = clinicId;
        ConsultationId = consultationId;
        PetId = petId;
        VeterinarianId = veterinarianId;
        Summary = summary;
        Observations = observations;
        GeneratedAt = DateTime.UtcNow;
    }
}