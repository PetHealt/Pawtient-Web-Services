namespace pawtient_project.Clinic.Interfaces.Rest.Resources;

public record PetResource(
    int Id,
    string Name,
    string Species,
    string Breed,
    int Age);
