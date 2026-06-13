using Microsoft.EntityFrameworkCore;
using pawtient_project.Profiles.Domain.Models.Aggregates;
using pawtient_project.Profiles.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Profiles.Infrastructure.Persistence.Repositories;

public class VeterinarianRepository(AppDbContext context)
    : BaseRepository<Veterinarian>(context), IVeterinarianRepository
{
    public async Task<Veterinarian?> FindByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await Context.Veterinarians
            .FirstOrDefaultAsync(v => v.UserId == userId, cancellationToken);
    }
}