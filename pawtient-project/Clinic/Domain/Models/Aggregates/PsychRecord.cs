namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class PsychRecord
{
    public int Id { get; private set; }
    public int MedicalRecordId { get; private set; }
    public int? ConsultationId { get; private set; }
    public string? Behavior { get; private set; }
    public string? Triggers { get; private set; }
    public string? Treatment { get; private set; }
    public byte? AnxietyScale { get; private set; }
    public DateTime RecordedAt { get; private set; }

    public MedicalRecord? MedicalRecord { get; private set; }

    public PsychRecord() { }

    public PsychRecord(int medicalRecordId, int? consultationId, string? behavior,
        string? triggers, string? treatment, byte? anxietyScale)
    {
        MedicalRecordId = medicalRecordId;
        ConsultationId = consultationId;
        Behavior = behavior;
        Triggers = triggers;
        Treatment = treatment;
        AnxietyScale = anxietyScale;
        RecordedAt = DateTime.UtcNow;
    }
}