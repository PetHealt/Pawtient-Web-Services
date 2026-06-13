using Microsoft.EntityFrameworkCore;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Infrastructure.Persistence.Repositories;

public class SupplierRepository(AppDbContext context): BaseRepository<Supplier>(context), ISupplierRepository
{
    public async Task<IEnumerable<Supplier>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.Suppliers
            .Where(s => s.ClinicId == clinicId)
            .ToListAsync(cancellationToken);
    }
}