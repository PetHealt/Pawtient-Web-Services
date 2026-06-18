using pawtient_project.Report.Application.QueryServices;
using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Repositories;
using pawtient_project.Report.Interfaces.Rest.Resources;

namespace pawtient_project.Report.Application.Internal.QueryServices;

public class ReportQueryService : IReportQueryService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IAppointmentReportRepository _appointmentReportRepository;
    private readonly IInventoryReportRepository _inventoryReportRepository;

    public ReportQueryService(
        IInvoiceRepository invoiceRepository,
        IAppointmentReportRepository appointmentReportRepository,
        IInventoryReportRepository inventoryReportRepository)
    {
        _invoiceRepository = invoiceRepository;
        _appointmentReportRepository = appointmentReportRepository;
        _inventoryReportRepository = inventoryReportRepository;
    }

    public async Task<ReportSummaryResource> GenerateGeneralReportAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        var invoices = await _invoiceRepository.FindByClinicIdAsync(clinicId, cancellationToken);
        var totalRevenue = invoices.Sum(i => i.Amount);
        
        var inventoryReports = await _inventoryReportRepository.FindByClinicIdAsync(clinicId, cancellationToken);
        var latestInventory = inventoryReports.OrderByDescending(r => r.GeneratedAt).FirstOrDefault();
        var totalExpenses = latestInventory?.TotalInventoryValue ?? 0;
        var lowStockAlerts = latestInventory?.LowStockCount ?? 0;
        
        var appointmentReports = await _appointmentReportRepository.FindByClinicIdAsync(clinicId, cancellationToken);
        var latestAppointments = appointmentReports.OrderByDescending(r => r.GeneratedAt).FirstOrDefault();
        var totalAppointments = latestAppointments?.TotalAppointments ?? 0;

        return new ReportSummaryResource(
            totalRevenue,
            totalExpenses,
            totalRevenue - totalExpenses,
            lowStockAlerts,
            totalAppointments
        );
    }

    public async Task<IEnumerable<Invoice>> GetInvoicesByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
        => await _invoiceRepository.FindByClinicIdAsync(clinicId, cancellationToken);
}