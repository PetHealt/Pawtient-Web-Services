using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Interfaces.Rest.Transform;

public static class ProductResourceAssembler {
    public static ProductResource ToResource(Product entity) => 
        new(entity.Id, entity.ClinicId, entity.Name, entity.Stock, entity.UnitPrice);
}