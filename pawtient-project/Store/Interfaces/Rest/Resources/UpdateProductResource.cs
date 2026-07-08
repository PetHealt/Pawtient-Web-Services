namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record UpdateProductResource(
    string Name,
    int Stock,
    decimal Price);
