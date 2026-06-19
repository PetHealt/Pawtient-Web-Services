namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record SupplierResource(
    int Id, int ClinicId, string Name, string? ContactEmail, string? Phone, string? Ruc);