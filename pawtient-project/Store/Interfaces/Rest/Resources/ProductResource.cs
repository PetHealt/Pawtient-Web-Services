namespace pawtient_project.Store.Interfaces.Rest.Resources;

public record ProductResource(
    int Id,
    string Name,
    int Stock,
    decimal Price);
