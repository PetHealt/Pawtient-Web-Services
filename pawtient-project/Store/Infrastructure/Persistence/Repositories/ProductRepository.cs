using Microsoft.EntityFrameworkCore;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Infrastructure.Persistence.Repositories;

public class ProductRepository(AppDbContext context): BaseRepository<Product>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.Products
            .Where(p => p.ClinicId == clinicId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> FindLowStockByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.Products
            .Where(p => p.ClinicId == clinicId && p.Stock <= p.MinimumStock)
            .ToListAsync(cancellationToken);
    }
}