using pawtient_project.Store.Application.QueryServices;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public async Task<IEnumerable<Product>> FindByClinicIdAsync(int clinicId, CancellationToken ct) 
        => await productRepository.FindByClinicIdAsync(clinicId, ct);

    public async Task<Product?> GetByIdAsync(int id, CancellationToken ct) 
        => await productRepository.FindByIdAsync(id, ct);
}