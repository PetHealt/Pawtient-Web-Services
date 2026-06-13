namespace pawtient_project.Profiles.Domain.Models.Aggregates;

public class Specialization
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Specialization() { }

    public Specialization(string name)
    {
        Name = name;
    }
}