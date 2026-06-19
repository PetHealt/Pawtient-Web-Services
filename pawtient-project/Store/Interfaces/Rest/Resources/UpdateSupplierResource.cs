namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record UpdateSupplierResource(
    string Name, string? ContactEmail, string? Phone, string? Ruc);