using pawtient_project.Clinic.Application.CommandServices;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Clinic.Interfaces.Rest.Resources;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Clinic.Application.Internal.CommandServices;

public class PetCommandService : IPetCommandService
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public PetCommandService(IPetRepository petRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Pet> CreateAsync(CreatePetResource resource, CancellationToken cancellationToken = default)
    {
        var clinicId = await _currentUserService.GetClinicIdAsync(cancellationToken);
        var pet = new Pet(clinicId, resource.Name, resource.Species, resource.Breed, resource.Age);
        await _petRepository.AddAsync(pet, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return pet;
    }

    public async Task<Pet?> UpdateAsync(int id, UpdatePetResource resource, CancellationToken cancellationToken = default)
    {
        var pet = await _petRepository.FindByIdAsync(id, cancellationToken);
        if (pet is null) return null;
        pet.Update(resource.Name, resource.Species, resource.Breed, resource.Age);
        _petRepository.Update(pet);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return pet;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var pet = await _petRepository.FindByIdAsync(id, cancellationToken);
        if (pet is null) return false;
        _petRepository.Remove(pet);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }
}
