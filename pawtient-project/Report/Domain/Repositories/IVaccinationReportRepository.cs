using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Report.Domain.Repositories;

public interface IVaccinationReportRepository : IBaseRepository<VaccinationReport>
{
    Task<IEnumerable<VaccinationReport>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}