using Microsoft.EntityFrameworkCore;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;

namespace pawtient_project.Store.Domain.Repositories;

public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<IEnumerable<Supplier>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default);
}