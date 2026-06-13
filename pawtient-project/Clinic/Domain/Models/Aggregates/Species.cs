namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class Species
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Species() { }

    public Species(string name)
    {
        Name = name;
    }
}