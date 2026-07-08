namespace pawtient_project.Plans.Interfaces.Rest.Resources;

public record PlanResource(
    string Name,
    string Description,
    decimal Price);
