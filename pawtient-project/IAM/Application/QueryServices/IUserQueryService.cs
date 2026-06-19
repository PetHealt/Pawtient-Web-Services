using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Models.Queries;

namespace pawtient_project.IAM.Application.QueryServices;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}