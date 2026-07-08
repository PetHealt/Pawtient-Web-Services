using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Store.Application.CommandServices;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;
using pawtient_project.Store.Interfaces.Rest.Resources;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Store.Application.Internal.CommandServices;

public class SupplierCommandService(ISupplierRepository repository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : ISupplierCommandService
{
    public async Task<Supplier> CreateAsync(CreateSupplierResource res, CancellationToken ct)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(ct);
        var supplier = new Supplier(clinicId, res.CompanyName, res.Contact, res.Category);
        await repository.AddAsync(supplier, ct);
        await unitOfWork.CompleteAsync(ct);
        return supplier;
    }

    public async Task<Supplier?> UpdateAsync(int id, UpdateSupplierResource res, CancellationToken ct)
    {
        var supplier = await repository.FindByIdAsync(id, ct);
        if (supplier == null) return null;
        supplier.Update(res.CompanyName, res.Contact, res.Category);
        repository.Update(supplier);
        await unitOfWork.CompleteAsync(ct);
        return supplier;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var supplier = await repository.FindByIdAsync(id, ct);
        if (supplier == null) return false;
        repository.Remove(supplier);
        await unitOfWork.CompleteAsync(ct);
        return true;
    }
}
