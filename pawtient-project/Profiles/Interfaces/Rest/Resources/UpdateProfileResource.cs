namespace pawtient_project.Profiles.Interfaces.Rest.Resources;

public record UpdateProfileResource(
    string FullName,
    string Email,
    string ClinicName);
