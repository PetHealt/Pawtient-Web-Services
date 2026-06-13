namespace pawtient_project.Profiles.Domain.Models.Commands;

public record CreateClinicCommand(
    int UserId,
    string Name,
    string? Address,
    string? Phone,
    string? Ruc
);