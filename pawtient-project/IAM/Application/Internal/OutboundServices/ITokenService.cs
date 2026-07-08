using pawtient_project.IAM.Domain.Models.Aggregates;

namespace pawtient_project.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
}
