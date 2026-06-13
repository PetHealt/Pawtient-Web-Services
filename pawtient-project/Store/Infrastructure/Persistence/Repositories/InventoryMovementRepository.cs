using Microsoft.EntityFrameworkCore;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Infrastructure.Persistence.Repositories;

public class InventoryMovementRepository(AppDbContext context): BaseRepository<InventoryMovement>(context), IInventoryMovementRepository
{
    public async Task<IEnumerable<InventoryMovement>> FindByProductIdAsync(int productId, CancellationToken cancellationToken = default)
    {
        return await Context.InventoryMovements
            .Where(i => i.ProductId == productId)
            .ToListAsync(cancellationToken);
    }
}