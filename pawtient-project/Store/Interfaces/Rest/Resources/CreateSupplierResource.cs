namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record CreateSupplierResource(
    int ClinicId, string Name, string? ContactEmail, 
    string? Phone, string? Ruc);