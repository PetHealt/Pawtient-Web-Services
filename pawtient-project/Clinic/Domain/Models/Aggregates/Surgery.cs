namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Surgery
{
    public int Id { get; private set; }
    public int ConsultationId { get; private set; }
    public string Procedure { get; private set; }
    public int? DurationMinutes { get; private set; }
    public string Anesthesia { get; private set; }
    public string? Notes { get; private set; }
    public string Outcome { get; private set; }

    public Consultation? Consultation { get; private set; }

    public Surgery() { }

    public Surgery(int consultationId, string procedure, int? durationMinutes,
        string anesthesia, string? notes)
    {
        ConsultationId = consultationId;
        Procedure = procedure;
        DurationMinutes = durationMinutes;
        Anesthesia = anesthesia;
        Notes = notes;
        Outcome = "IN_PROGRESS";
    }
}