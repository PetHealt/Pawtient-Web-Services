using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Clinic.Domain.Repositories;

public interface IPetRepository : IBaseRepository<Pet>
{
    Task<IEnumerable<Pet>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}