using pawtient_project.Profiles.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Profiles.Domain.Repositories;

public interface IVeterinarianRepository : IBaseRepository<Veterinarian>
{
    Task<Veterinarian?> FindByUserIdAsync(int userId, CancellationToken cancellationToken = default);
}