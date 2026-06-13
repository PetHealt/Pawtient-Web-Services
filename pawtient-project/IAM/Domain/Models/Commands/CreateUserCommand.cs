namespace pawtient_project.IAM.Domain.Models.Commands;

public record CreateUserCommand(
    string FullName,
    string Email,
    string Password,
    string Role
);