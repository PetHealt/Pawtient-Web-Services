using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Report.Domain.Repositories;

public interface IConsultationReportRepository : IBaseRepository<ConsultationReport>
{
    Task<IEnumerable<ConsultationReport>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}