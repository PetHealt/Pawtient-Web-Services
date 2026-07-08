namespace pawtient_project.Profiles.Interfaces.Rest.Resources;

public record ProfileResource(
    string FullName,
    string Email,
    string Role,
    string ClinicName,
    string Plan);
