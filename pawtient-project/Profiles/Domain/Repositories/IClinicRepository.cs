using pawtient_project.Shared.Domain.Repositories;
using ClinicEntity = pawtient_project.Profiles.Domain.Models.Aggregates.Clinic;

namespace pawtient_project.Profiles.Domain.Repositories;

public interface IClinicRepository : IBaseRepository<ClinicEntity>
{
    Task<ClinicEntity?> FindByUserIdAsync(int userId, CancellationToken cancellationToken = default);
}