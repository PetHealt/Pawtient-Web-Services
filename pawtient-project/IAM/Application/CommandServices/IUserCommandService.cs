using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Models.Commands;

namespace pawtient_project.IAM.Application.CommandServices;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}