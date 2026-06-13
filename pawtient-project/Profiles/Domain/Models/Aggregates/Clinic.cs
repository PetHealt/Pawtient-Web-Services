namespace pawtient_project.Profiles.Domain.Models.Aggregates;

public class Clinic
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Name { get; private set; }
    public string? Address { get; private set; }
    public string? Phone { get; private set; }
    public string? Ruc { get; private set; }

    public Clinic() { }

    public Clinic(int userId, string name, string? address, string? phone, string? ruc)
    {
        UserId = userId;
        Name = name;
        Address = address;
        Phone = phone;
        Ruc = ruc;
    }
}