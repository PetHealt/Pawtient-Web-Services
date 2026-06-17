namespace pawtient_project.Report.Interfaces.Rest.Resources;

public record CreateInvoiceCommand(
    int ClinicId,
    int? AppointmentId,
    int? ConsultationId,
    string PetName,
    string? OwnerName,
    decimal Amount,
    string? Notes
    );