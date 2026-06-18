using pawtient_project.Clinic.Application.CommandServices;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Clinic.Interfaces.Rest.Resources;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Clinic.Application.Internal.CommandServices;

public class PetCommandService : IPetCommandService
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PetCommandService(IPetRepository petRepository, IUnitOfWork unitOfWork)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Pet> CreateAsync(CreatePetResource resource, CancellationToken cancellationToken = default)
    {
        var pet = new Pet(
            resource.ClinicId,
            resource.SpeciesId,
            resource.BreedId,
            resource.Name,
            resource.BirthDate,
            resource.Sex,
            resource.Microchip,
            resource.CoatColor,
            resource.WeightKg
        );
        await _petRepository.AddAsync(pet, cancellationToken);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return pet;
    }

    public async Task<Pet?> UpdateAsync(int id, UpdatePetResource resource, CancellationToken cancellationToken = default)
    {
        var pet = await _petRepository.FindByIdAsync(id, cancellationToken);
        if (pet is null) return null;
        pet.Update(
            resource.SpeciesId,
            resource.BreedId,
            resource.Name,
            resource.BirthDate,
            resource.Sex,
            resource.Microchip,
            resource.CoatColor,
            resource.WeightKg
        );
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