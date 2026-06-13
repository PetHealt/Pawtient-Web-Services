namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class VitalSign
{
    public int Id { get; private set; }
    public int ConsultationId { get; private set; }
    public decimal? Temperature { get; private set; }
    public decimal? Weight { get; private set; }
    public int? HeartRate { get; private set; }
    public int? RespiratoryRate { get; private set; }
    public byte? PainScale { get; private set; }
    public DateTime RecordedAt { get; private set; }

    public Consultation? Consultation { get; private set; }

    public VitalSign() { }

    public VitalSign(int consultationId, decimal? temperature, decimal? weight,
        int? heartRate, int? respiratoryRate, byte? painScale)
    {
        ConsultationId = consultationId;
        Temperature = temperature;
        Weight = weight;
        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
        PainScale = painScale;
        RecordedAt = DateTime.UtcNow;
    }
}