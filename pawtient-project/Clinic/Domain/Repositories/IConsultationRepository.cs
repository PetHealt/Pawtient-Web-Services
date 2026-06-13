using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Clinic.Domain.Repositories;

public interface IConsultationRepository : IBaseRepository<Consultation>
{
    Task<IEnumerable<Consultation>> FindByMedicalRecordIdAsync(int medicalRecordId, CancellationToken cancellationToken = default);
}