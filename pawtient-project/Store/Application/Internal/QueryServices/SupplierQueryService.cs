using pawtient_project.Store.Application.QueryServices;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Application.Internal.QueryServices;

public class SupplierQueryService(ISupplierRepository repository) : ISupplierQueryService
{
    public async Task<IEnumerable<Supplier>> FindByClinicIdAsync(int clinicId, CancellationToken ct) 
        => await repository.FindByClinicIdAsync(clinicId, ct);

    public async Task<Supplier?> GetByIdAsync(int id, CancellationToken ct) 
        => await repository.FindByIdAsync(id, ct);
}