using Microsoft.EntityFrameworkCore;
using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.IAM.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext context) 
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await Context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await Context.Users
            .AnyAsync(u => u.Email == email, cancellationToken);
    }
}