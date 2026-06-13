using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Clinic.Domain.Repositories;

public interface IMedicalRecordRepository : IBaseRepository<MedicalRecord>
{
    Task<MedicalRecord?> FindByPetIdAsync(int petId, CancellationToken cancellationToken = default);
}