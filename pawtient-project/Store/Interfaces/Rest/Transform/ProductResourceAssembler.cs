using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Interfaces.Rest.Transform;

public static class ProductResourceAssembler
{
    public static ProductResource ToResource(Product product)
    {
        return new ProductResource(
            product.Id,
            product.Name,
            product.Stock,
            product.UnitPrice);
    }
}
