namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class IcdCode
{
    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Description { get; private set; }

    public IcdCode() { }

    public IcdCode(string code, string description)
    {
        Code = code;
        Description = description;
    }
}