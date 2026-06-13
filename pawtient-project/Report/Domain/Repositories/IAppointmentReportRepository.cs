using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Report.Domain.Repositories;

public interface IAppointmentReportRepository : IBaseRepository<AppointmentReport>
{
    Task<IEnumerable<AppointmentReport>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}