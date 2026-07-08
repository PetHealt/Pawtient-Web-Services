using pawtient_project.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace pawtient_project.IAM.Infrastructure.Hashing.BCrypt;

public class HashingService : IHashingService
{
    public string HashPassword(string password) => BCryptNet.HashPassword(password);

    public bool VerifyPassword(string password, string passwordHash) => BCryptNet.Verify(password, passwordHash);
}
