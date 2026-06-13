using Microsoft.EntityFrameworkCore;
using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Report.Infrastructure.Persistence.Repositories;

public class InvoiceRepository(AppDbContext context)
    : BaseRepository<Invoice>(context), IInvoiceRepository
{
    public async Task<IEnumerable<Invoice>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.Invoices
            .Where(i => i.ClinicId == clinicId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Invoice>> FindByStatusAsync(string status, CancellationToken cancellationToken = default)
    {
        return await Context.Invoices
            .Where(i => i.Status == status)
            .ToListAsync(cancellationToken);
    }
}