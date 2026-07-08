namespace pawtient_project.Clinic.Interfaces.Rest.Resources;

public record UpdatePetResource(
    string Name,
    string Species,
    string Breed,
    int Age);
