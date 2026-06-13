using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Store.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> FindLowStockByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}