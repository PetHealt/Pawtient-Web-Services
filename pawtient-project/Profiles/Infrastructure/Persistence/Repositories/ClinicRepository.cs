using Microsoft.EntityFrameworkCore;
using pawtient_project.Profiles.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using ClinicEntity = pawtient_project.Profiles.Domain.Models.Aggregates.Clinic;

namespace pawtient_project.Profiles.Infrastructure.Persistence.Repositories;

public class ClinicRepository(AppDbContext context)
    : BaseRepository<ClinicEntity>(context), IClinicRepository
{
    public async Task<ClinicEntity?> FindByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await Context.Clinics
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
    }
}