using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Store.Application.CommandServices;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product> CreateAsync(CreateProductResource res, CancellationToken ct)
    {
        var product = new Product(res.ClinicId, res.CategoryId, res.SupplierId, res.Name, res.Description, res.UnitPrice, res.Stock, res.MinimumStock);
        await productRepository.AddAsync(product, ct);
        await unitOfWork.CompleteAsync(ct);
        return product;
    }

    public async Task<Product?> UpdateAsync(int id, UpdateProductResource res, CancellationToken ct)
    {
        var product = await productRepository.FindByIdAsync(id, ct);
        if (product == null) return null;
        
        product.Update(res.CategoryId, res.SupplierId, res.Name, res.Description, res.UnitPrice, res.Stock, res.MinimumStock);
        
        productRepository.Update(product);
        await unitOfWork.CompleteAsync(ct);
        return product;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var product = await productRepository.FindByIdAsync(id, ct);
        if (product == null) return false;
        productRepository.Remove(product);
        await unitOfWork.CompleteAsync(ct);
        return true;
    }
}