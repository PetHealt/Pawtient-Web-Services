using Microsoft.EntityFrameworkCore;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Clinic.Infrastructure.Persistence.Repositories;

public class BreedRepository(AppDbContext context)
    : BaseRepository<Breed>(context), IBreedRepository
{
    public async Task<IEnumerable<Breed>> FindBySpeciesIdAsync(int speciesId, CancellationToken cancellationToken = default)
    {
        return await Context.Breeds
            .Where(b => b.SpeciesId == speciesId)
            .ToListAsync(cancellationToken);
    }
}