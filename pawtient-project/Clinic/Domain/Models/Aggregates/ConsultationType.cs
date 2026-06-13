namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class ConsultationType
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ConsultationType() { }

    public ConsultationType(string name)
    {
        Name = name;
    }
}