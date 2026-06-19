using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Interfaces.Rest.Resources;

namespace pawtient_project.Store.Interfaces.Rest.Transform;

public static class SupplierResourceAssembler {
    public static SupplierResource ToResource(Supplier entity) => 
        new(entity.Id, entity.ClinicId, entity.Name, entity.ContactEmail, entity.Phone, entity.Ruc);
}