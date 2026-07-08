namespace pawtient_project.Store.Domain.Models.Aggregates;

public class Supplier
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public string Name { get; private set; }
    public string? ContactEmail { get; private set; }
    public string? Phone { get; private set; }
    public string? Ruc { get; private set; }
    public string? Contact { get; private set; }
    public string? Category { get; private set; }

    public Supplier() { }

    public Supplier(int clinicId, string name, string? contactEmail, string? phone, string? ruc)
    {
        ClinicId = clinicId;
        Name = name;
        ContactEmail = contactEmail;
        Phone = phone;
        Ruc = ruc;
        Contact = string.Join(" / ", new[] { phone, contactEmail }.Where(value => !string.IsNullOrWhiteSpace(value)));
        Category = ruc;
    }

    public Supplier(int clinicId, string name, string? contact, string? category)
    {
        ClinicId = clinicId;
        Name = name;
        Contact = contact;
        Category = category;
    }

    public void Update(string name, string? contactEmail, string? phone, string? ruc)
    {
        Name = name;
        ContactEmail = contactEmail;
        Phone = phone;
        Ruc = ruc;
        Contact = string.Join(" / ", new[] { phone, contactEmail }.Where(value => !string.IsNullOrWhiteSpace(value)));
    }

    public void Update(string name, string? contact, string? category)
    {
        Name = name;
        Contact = contact;
        Category = category;
    }
}
