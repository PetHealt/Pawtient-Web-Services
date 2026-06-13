namespace pawtient_project.Store.Domain.Models.Aggregates;

public class Supplier
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public string Name { get; private set; }
    public string? ContactEmail { get; private set; }
    public string? Phone { get; private set; }
    public string? Ruc { get; private set; }

    public Supplier() { }

    public Supplier(int clinicId, string name, string? contactEmail, string? phone, string? ruc)
    {
        ClinicId = clinicId;
        Name = name;
        ContactEmail = contactEmail;
        Phone = phone;
        Ruc = ruc;
    }
}