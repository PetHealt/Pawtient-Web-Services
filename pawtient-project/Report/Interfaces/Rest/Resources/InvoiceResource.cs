namespace pawtient_project.Report.Interfaces.Rest.Resources;

public record InvoiceResource(
    int Id,
    DateTime Date,
    string Patient,
    string? Client,
    decimal Amount);
