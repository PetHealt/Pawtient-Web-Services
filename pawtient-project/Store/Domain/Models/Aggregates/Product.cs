namespace pawtient_project.Store.Domain.Models.Aggregates;

public class Product
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public int? CategoryId { get; private set; }
    public int? SupplierId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Stock { get; private set; }
    public int MinimumStock { get; private set; }
    public bool IsActive { get; private set; }

    public ProductCategory? Category { get; private set; }
    public Supplier? Supplier { get; private set; }

    public Product() { }

    public Product(int clinicId, int? categoryId, int? supplierId, string name,
        string? description, decimal unitPrice, int stock, int minimumStock)
    {
        ClinicId = clinicId;
        CategoryId = categoryId;
        SupplierId = supplierId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        Stock = stock;
        MinimumStock = minimumStock;
        IsActive = true;
    }
}