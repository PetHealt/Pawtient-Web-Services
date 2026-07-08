namespace pawtient_project.Report.Interfaces.Rest.Resources;

public record CreateInvoiceCommand(
    int? AppointmentId,
    string Patient,
    string? Client,
    DateTime Date,
    decimal Amount);
