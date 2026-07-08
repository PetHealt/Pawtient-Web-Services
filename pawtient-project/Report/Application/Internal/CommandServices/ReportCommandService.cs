using pawtient_project.Report.Application.CommandServices;
using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Repositories;
using pawtient_project.Report.Interfaces.Rest.Resources;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Report.Application.Internal.CommandServices;

public class ReportCommandService : IReportCommandService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public ReportCommandService(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Invoice> CreateInvoiceAsync(CreateInvoiceCommand command, CancellationToken cancellationToken = default)
    {
        var clinicId = await _currentUserService.GetClinicIdAsync(cancellationToken);
        var invoice = new Invoice(clinicId, command.AppointmentId, command.Patient, command.Client, command.Date, command.Amount);
        await _invoiceRepository.AddAsync(invoice, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return invoice;
    }

    public async Task<bool> DeleteInvoiceAsync(int id, CancellationToken cancellationToken = default)
    {
        var invoice = await _invoiceRepository.FindByIdAsync(id, cancellationToken);
        if (invoice is null) return false;
        _invoiceRepository.Remove(invoice);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }
}
