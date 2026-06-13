namespace pawtient_project.Profiles.Domain.Models.Commands;

public record CreateVeterinarianCommand(
    int UserId,
    string? LicenseNumber,
    int? SpecializationId
);