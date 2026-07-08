namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record CreateSupplierResource(
    string CompanyName,
    string? Contact,
    string? Category);
