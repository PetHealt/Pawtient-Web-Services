using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Interfaces.Rest.Transform;

public static class SupplierResourceAssembler
{
    public static SupplierResource ToResource(Supplier supplier)
    {
        return new SupplierResource(
            supplier.Id,
            supplier.Name,
            supplier.Contact,
            supplier.Category);
    }
}
