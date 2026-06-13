using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Report.Domain.Repositories;

public interface IInvoiceRepository : IBaseRepository<Invoice>
{
    Task<IEnumerable<Invoice>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Invoice>> FindByStatusAsync(string status, CancellationToken cancellationToken = default);
}