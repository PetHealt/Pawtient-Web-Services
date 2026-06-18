namespace pawtient_project.Report.Interfaces.Rest.Resources;

public record InvoiceResource(
    int Id,
    int ClinicId,
    int? AppointmentId,
    int? ConsultationId,
    string PetName,
    string? OwnerName,
    decimal Amount,
    DateTime Date,
    string Status,
    string? Notes
    );