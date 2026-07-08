namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record CreateProductResource(
    string Name,
    int Stock,
    decimal Price);
