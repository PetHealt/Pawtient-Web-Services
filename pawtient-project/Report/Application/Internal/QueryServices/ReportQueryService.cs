using pawtient_project.Report.Application.QueryServices;
using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Repositories;
using pawtient_project.Report.Interfaces.Rest.Resources;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Report.Application.Internal.QueryServices;

public class ReportQueryService : IReportQueryService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IProductRepository _productRepository;

    public ReportQueryService(
        IInvoiceRepository invoiceRepository,
        IProductRepository productRepository)
    {
        _invoiceRepository = invoiceRepository;
        _productRepository = productRepository;
    }

    public async Task<ReportSummaryResource> GenerateGeneralReportAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        var invoices = await _invoiceRepository.FindByClinicIdAsync(clinicId, cancellationToken);
        var totalRevenue = invoices.Sum(i => i.Amount);

        var lowStockProducts = await _productRepository.FindLowStockByClinicIdAsync(clinicId, cancellationToken);
        var lowStockAlerts = lowStockProducts.Count();

        return new ReportSummaryResource(
            totalRevenue,
            totalRevenue,
            lowStockAlerts
        );
    }

    public async Task<IEnumerable<Invoice>> GetInvoicesByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
        => await _invoiceRepository.FindByClinicIdAsync(clinicId, cancellationToken);
}
