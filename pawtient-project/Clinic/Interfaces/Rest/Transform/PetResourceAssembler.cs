using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Interfaces.Rest.Resources;

namespace pawtient_project.Clinic.Interfaces.Rest.Transform;

public static class PetResourceAssembler
{
    public static PetResource ToResource(Pet pet)
    {
        return new PetResource(
            pet.Id,
            pet.Name,
            pet.SpeciesName,
            pet.BreedName,
            pet.Age);
    }
}
