namespace pawtient_project.Store.Domain.Models.Aggregates;

public class ProductCategory
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ProductCategory() { }

    public ProductCategory(string name)
    {
        Name = name;
    }
}