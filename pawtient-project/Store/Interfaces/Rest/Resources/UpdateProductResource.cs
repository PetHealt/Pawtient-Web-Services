namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record UpdateProductResource(
    int? CategoryId, int? SupplierId, 
    string Name, string? Description, decimal UnitPrice, 
    int Stock, int MinimumStock);