namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Prescription
{
    public int Id { get; private set; }
    public int ConsultationId { get; private set; }
    public string? Instructions { get; private set; }
    public DateOnly? StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }

    public Consultation? Consultation { get; private set; }

    public Prescription() { }

    public Prescription(int consultationId, string? instructions, DateOnly? startDate, DateOnly? endDate)
    {
        ConsultationId = consultationId;
        Instructions = instructions;
        StartDate = startDate;
        EndDate = endDate;
    }
}