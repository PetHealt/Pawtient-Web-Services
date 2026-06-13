namespace pawtient_project.Report.Domain.Models.Aggregates;

public class InventoryReport
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public DateTime GeneratedAt { get; private set; }
    public int TotalProducts { get; private set; }
    public int LowStockCount { get; private set; }
    public decimal TotalInventoryValue { get; private set; }
    public string? Notes { get; private set; }

    public InventoryReport() { }

    public InventoryReport(int clinicId, int totalProducts,
        int lowStockCount, decimal totalInventoryValue, string? notes)
    {
        ClinicId = clinicId;
        TotalProducts = totalProducts;
        LowStockCount = lowStockCount;
        TotalInventoryValue = totalInventoryValue;
        Notes = notes;
        GeneratedAt = DateTime.UtcNow;
    }
}