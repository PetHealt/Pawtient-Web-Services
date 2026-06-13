using Microsoft.EntityFrameworkCore;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Clinic.Infrastructure.Persistence.Repositories;

public class PetRepository(AppDbContext context)
    : BaseRepository<Pet>(context), IPetRepository
{
    public async Task<IEnumerable<Pet>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.Pets
            .Where(p => p.ClinicId == clinicId)
            .ToListAsync(cancellationToken);
    }
}