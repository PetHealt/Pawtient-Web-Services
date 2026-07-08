namespace pawtient_project.IAM.Interfaces.Rest.Resources;

public record AuthenticatedUserResource(
    string Token,
    int Id,
    string FullName,
    string Email,
    string Role,
    string ClinicName,
    string Plan);
