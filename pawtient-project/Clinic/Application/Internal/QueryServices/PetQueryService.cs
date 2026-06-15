using pawtient_project.Clinic.Application.QueryServices;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;

namespace pawtient_project.Clinic.Application.Internal.QueryServices;

public class PetQueryService : IPetQueryService
{
    private readonly IPetRepository _petRepository;
    
    public PetQueryService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }
    
    public async Task<Pet?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _petRepository.FindByIdAsync(id, cancellationToken);

    public async Task<IEnumerable<Pet>> GetByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
        => await _petRepository.FindByClinicIdAsync(clinicId, cancellationToken);
    
    
}