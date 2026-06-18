using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Interfaces.Rest.Resources;

namespace pawtient_project.Report.Application.CommandServices;

public interface IReportCommandService
{
    Task<Invoice> CreateInvoiceAsync(CreateInvoiceCommand command, CancellationToken cancellationToken = default);
    Task<bool> DeleteInvoiceAsync(int id, CancellationToken cancellationToken = default);
}