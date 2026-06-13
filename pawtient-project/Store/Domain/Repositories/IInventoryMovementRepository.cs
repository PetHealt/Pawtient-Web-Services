using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Store.Domain.Repositories;

public interface IInventoryMovementRepository : IBaseRepository<InventoryMovement>
{
    Task<IEnumerable<InventoryMovement>> FindByProductIdAsync(int productId, CancellationToken cancellationToken = default);
}