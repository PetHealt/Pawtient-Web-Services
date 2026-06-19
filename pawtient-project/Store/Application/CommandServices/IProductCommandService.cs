using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Application.CommandServices;

public interface IProductCommandService
{
    Task<Product> CreateAsync(CreateProductResource resource, CancellationToken ct = default);
    Task<Product?> UpdateAsync(int id, UpdateProductResource resource, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}