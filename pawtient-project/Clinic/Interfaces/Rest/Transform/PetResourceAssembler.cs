using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Interfaces.Rest.Resources;

namespace pawtient_project.Clinic.Interfaces.Rest.Transform;


public static class PetResourceAssembler
{
    public static PetResource ToResource(Pet pet) => new PetResource(
        pet.Id,
        pet.ClinicId,
        pet.SpeciesId,
        pet.BreedId,
        pet.Name,
        pet.BirthDate,
        pet.Sex,
        pet.Microchip,
        pet.CoatColor,
        pet.WeightKg,
        pet.IsActive
    );


}