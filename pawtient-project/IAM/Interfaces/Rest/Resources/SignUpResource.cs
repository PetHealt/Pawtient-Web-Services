namespace pawtient_project.IAM.Interfaces.Rest.Resources;

public record SignUpResource(
    string FullName,
    string Email,
    string Password,
    string Role,
    string ClinicName);
