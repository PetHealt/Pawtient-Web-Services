using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Application.CommandServices;

public interface ISupplierCommandService
{
    Task<Supplier> CreateAsync(CreateSupplierResource resource, CancellationToken cancellationToken = default);
    Task<Supplier?> UpdateAsync(int id, UpdateSupplierResource resource, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}