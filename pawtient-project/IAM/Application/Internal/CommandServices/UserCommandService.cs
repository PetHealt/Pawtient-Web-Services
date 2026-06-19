using pawtient_project.IAM.Application.CommandServices;
using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Models.Commands;
using pawtient_project.IAM.Domain.Repositories;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.IAM.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        if (await userRepository.ExistsByEmailAsync(command.Email)) return null;
        
        var user = new User(command.FullName, command.Email, command.Password, command.Role);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        return user;
    }
}