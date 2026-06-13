using Microsoft.EntityFrameworkCore;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Infrastructure.Persistence.Repositories;

public class StockAlertRepository(AppDbContext context): BaseRepository<StockAlert>(context), IStockAlertRepository
{
    public async Task<IEnumerable<StockAlert>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.StockAlerts
            .Where(s => s.ClinicId == clinicId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<StockAlert>> FindUnresolvedByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.StockAlerts
            .Where(s => s.ClinicId == clinicId && !s.Resolved)
            .ToListAsync(cancellationToken);
    }
}