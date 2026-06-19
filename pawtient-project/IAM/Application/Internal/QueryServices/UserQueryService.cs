using pawtient_project.IAM.Application.QueryServices;
using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Models.Queries;
using pawtient_project.IAM.Domain.Repositories;

namespace pawtient_project.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query) 
        => await userRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query) 
        => await userRepository.ListAsync();
}