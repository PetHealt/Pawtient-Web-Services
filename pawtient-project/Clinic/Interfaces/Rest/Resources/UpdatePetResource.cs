namespace pawtient_project.Clinic.Interfaces.Rest.Resources;

public record UpdatePetResource(
    int? SpeciesId,
    int? BreedId,
    string? Name,
    DateOnly? BirthDate,
    string? Sex,
    string? Microchip,
    string? CoatColor,
    decimal? WeightKg);