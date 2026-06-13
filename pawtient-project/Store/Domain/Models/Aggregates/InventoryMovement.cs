namespace pawtient_project.Store.Domain.Models.Aggregates;

public class InventoryMovement
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int? ConsultationId { get; private set; }
    public string Type { get; private set; }
    public int Quantity { get; private set; }
    public decimal? UnitCost { get; private set; }
    public DateTime Date { get; private set; }
    public string? Notes { get; private set; }

    public Product? Product { get; private set; }

    public InventoryMovement() { }

    public InventoryMovement(int productId, int? consultationId, string type,
        int quantity, decimal? unitCost, string? notes)
    {
        ProductId = productId;
        ConsultationId = consultationId;
        Type = type;
        Quantity = quantity;
        UnitCost = unitCost;
        Notes = notes;
        Date = DateTime.UtcNow;
    }
}