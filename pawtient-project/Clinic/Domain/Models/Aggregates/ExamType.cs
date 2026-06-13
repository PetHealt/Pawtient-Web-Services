namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class ExamType
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Category { get; private set; }

    public ExamType() { }

    public ExamType(string name, string? category)
    {
        Name = name;
        Category = category;
    }
}