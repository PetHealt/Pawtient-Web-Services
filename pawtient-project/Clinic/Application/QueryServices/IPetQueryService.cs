using pawtient_project.Clinic.Domain.Models.Aggregates;

namespace pawtient_project.Clinic.Application.QueryServices;

public interface IPetQueryService
{
    Task<Pet?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Pet>> GetByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}