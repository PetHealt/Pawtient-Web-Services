namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Vaccine
{
    public int Id { get; private set; }
    public int MedicalRecordId { get; private set; }
    public int ProductId { get; private set; }
    public int VeterinarianId { get; private set; }
    public DateOnly Date { get; private set; }
    public DateOnly? NextDate { get; private set; }
    public string? BatchNumber { get; private set; }
    public string Status { get; private set; }

    public MedicalRecord? MedicalRecord { get; private set; }

    public Vaccine() { }

    public Vaccine(int medicalRecordId, int productId, int veterinarianId,
        DateOnly date, DateOnly? nextDate, string? batchNumber)
    {
        MedicalRecordId = medicalRecordId;
        ProductId = productId;
        VeterinarianId = veterinarianId;
        Date = date;
        NextDate = nextDate;
        BatchNumber = batchNumber;
        Status = "APPLIED";
    }
}