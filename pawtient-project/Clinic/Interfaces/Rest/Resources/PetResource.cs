namespace pawtient_project.Clinic.Interfaces.Rest.Resources;

public record PetResource(
    int Id,
    int ClinicId,
    int SpeciesId,
    int? BreedId,
    string Name,
    DateOnly? BirthDate,
    string Sex,
    string? Microchip,
    string? CoatColor,
    decimal? WeightKg,
    bool IsActive);