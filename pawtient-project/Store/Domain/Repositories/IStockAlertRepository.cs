using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Store.Domain.Repositories;

public interface IStockAlertRepository : IBaseRepository<StockAlert>
{
    Task<IEnumerable<StockAlert>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
    Task<IEnumerable<StockAlert>> FindUnresolvedByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}