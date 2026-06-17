using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Interfaces.Rest.Resources;

namespace pawtient_project.Report.Application.QueryServices;

public interface IReportQueryService
{
    Task<ReportSummaryResource> GenerateGeneralReportAsync(int clinicId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Invoice>> GetInvoicesByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}