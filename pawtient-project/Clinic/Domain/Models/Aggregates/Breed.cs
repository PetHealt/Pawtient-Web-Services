namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Breed
{
    public int Id { get; private set; }
    public int SpeciesId { get; private set; }
    public string Name { get; private set; }

    public Species? Species { get; private set; }

    public Breed() { }

    public Breed(int speciesId, string name)
    {
        SpeciesId = speciesId;
        Name = name;
    }
}