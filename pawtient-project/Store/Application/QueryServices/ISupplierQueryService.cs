using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Store.Application.QueryServices;

public interface ISupplierQueryService
{
    Task<IEnumerable<Supplier>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
    Task<Supplier?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}