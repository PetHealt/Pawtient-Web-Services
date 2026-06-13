namespace pawtient_project.Report.Domain.Models.Aggregates;

public class Invoice
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int? AppointmentId { get; private set; }
    public int? ConsultationId { get; private set; }
    public string PetName { get; private set; }
    public string? OwnerName { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Status { get; private set; }
    public string? Notes { get; private set; }

    public Invoice() { }

    public Invoice(int clinicId, int? appointmentId, int? consultationId,
        string petName, string? ownerName, decimal amount, string? notes)
    {
        ClinicId = clinicId;
        AppointmentId = appointmentId;
        ConsultationId = consultationId;
        PetName = petName;
        OwnerName = ownerName;
        Amount = amount;
        Notes = notes;
        Date = DateTime.UtcNow;
        Status = "PENDING";
    }
}