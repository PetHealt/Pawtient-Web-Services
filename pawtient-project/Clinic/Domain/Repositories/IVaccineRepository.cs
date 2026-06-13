using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Clinic.Domain.Repositories;

public interface IVaccineRepository : IBaseRepository<Vaccine>
{
    Task<IEnumerable<Vaccine>> FindByMedicalRecordIdAsync(int medicalRecordId, CancellationToken cancellationToken = default);
}