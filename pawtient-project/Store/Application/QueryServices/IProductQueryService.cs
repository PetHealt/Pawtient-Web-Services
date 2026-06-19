using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Store.Application.QueryServices;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> FindByClinicIdAsync(int clinicId, CancellationToken ct = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
}