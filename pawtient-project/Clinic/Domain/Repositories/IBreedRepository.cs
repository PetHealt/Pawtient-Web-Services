using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Clinic.Domain.Repositories;

public interface IBreedRepository : IBaseRepository<Breed>
{
    Task<IEnumerable<Breed>> FindBySpeciesIdAsync(int speciesId, CancellationToken cancellationToken = default);
}