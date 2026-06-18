namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Pet
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int SpeciesId { get; private set; }
    public int? BreedId { get; private set; }
    public string Name { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public string Sex { get; private set; }
    public string? Microchip { get; private set; }
    public string? CoatColor { get; private set; }
    public decimal? WeightKg { get; private set; }
    public bool IsActive { get; private set; }

    public Species? Species { get; private set; }
    public Breed? Breed { get; private set; }

    public Pet() { }

    public Pet(int clinicId, int speciesId, int? breedId, string name,
        DateOnly? birthDate, string sex, string? microchip, string? coatColor, decimal? weightKg)
    {
        ClinicId = clinicId;
        SpeciesId = speciesId;
        BreedId = breedId;
        Name = name;
        BirthDate = birthDate;
        Sex = sex;
        Microchip = microchip;
        CoatColor = coatColor;
        WeightKg = weightKg;
        IsActive = true;
    }
    
    public void Update(int? speciesId, int? breedId, string? name,
        DateOnly? birthDate, string? sex, string? microchip, string? coatColor, decimal? weightKg)
    {
        if (speciesId.HasValue) SpeciesId = speciesId.Value;
        if (breedId.HasValue) BreedId = breedId.Value;
        if (name is not null) Name = name;
        if (birthDate.HasValue) BirthDate = birthDate.Value;
        if (sex is not null) Sex = sex;
        if (microchip is not null) Microchip = microchip;
        if (coatColor is not null) CoatColor = coatColor;
        if (weightKg.HasValue) WeightKg = weightKg.Value;
    }
}