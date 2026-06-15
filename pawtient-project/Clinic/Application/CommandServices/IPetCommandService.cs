using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Interfaces.Rest.Resources;

namespace pawtient_project.Clinic.Application.CommandServices;

public interface IPetCommandService
{
    Task<Pet> CreateAsync(CreatePetResource resource, CancellationToken cancellationToken = default);
    Task<Pet?> UpdateAsync(int id, UpdatePetResource resource, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}