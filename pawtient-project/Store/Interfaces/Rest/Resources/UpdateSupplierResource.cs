namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record UpdateSupplierResource(
    string CompanyName,
    string? Contact,
    string? Category);
