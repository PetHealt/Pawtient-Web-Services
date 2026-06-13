namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Diagnosis
{
    public int Id { get; private set; }
    public int ConsultationId { get; private set; }
    public int? IcdCodeId { get; private set; }
    public string Type { get; private set; }
    public string? Notes { get; private set; }

    public Consultation? Consultation { get; private set; }
    public IcdCode? IcdCode { get; private set; }

    public Diagnosis() { }

    public Diagnosis(int consultationId, int? icdCodeId, string type, string? notes)
    {
        ConsultationId = consultationId;
        IcdCodeId = icdCodeId;
        Type = type;
        Notes = notes;
    }
}