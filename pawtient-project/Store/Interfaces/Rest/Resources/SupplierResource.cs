namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record SupplierResource(
    int Id,
    string CompanyName,
    string? Contact,
    string? Category);
