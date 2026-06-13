namespace pawtient_project.Store.Domain.Models.Aggregates;

public class StockAlert
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int ClinicId { get; private set; }
    public string? Message { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Resolved { get; private set; }

    public Product? Product { get; private set; }

    public StockAlert() { }

    public StockAlert(int productId, int clinicId, string? message)
    {
        ProductId = productId;
        ClinicId = clinicId;
        Message = message;
        CreatedAt = DateTime.UtcNow;
        Resolved = false;
    }
}