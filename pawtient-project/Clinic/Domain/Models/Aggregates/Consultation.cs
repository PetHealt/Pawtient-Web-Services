namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Consultation
{
    public int Id { get; private set; }
    public int MedicalRecordId { get; private set; }
    public int VeterinarianId { get; private set; }
    public int? ConsultationTypeId { get; private set; }
    public DateTime Date { get; private set; }
    public string Status { get; private set; }
    public string? Notes { get; private set; }

    public MedicalRecord? MedicalRecord { get; private set; }
    public ConsultationType? ConsultationType { get; private set; }

    public Consultation() { }

    public Consultation(int medicalRecordId, int veterinarianId, int? consultationTypeId,
        DateTime date, string? notes)
    {
        MedicalRecordId = medicalRecordId;
        VeterinarianId = veterinarianId;
        ConsultationTypeId = consultationTypeId;
        Date = date;
        Notes = notes;
        Status = "IN_PROGRESS";
    }
}