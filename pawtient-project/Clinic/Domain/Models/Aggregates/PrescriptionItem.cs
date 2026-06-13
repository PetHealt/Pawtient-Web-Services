namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class PrescriptionItem
{
    public int Id { get; private set; }
    public int PrescriptionId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public string? Dosage { get; private set; }
    public string? Frequency { get; private set; }
    public string? Route { get; private set; }

    public Prescription? Prescription { get; private set; }

    public PrescriptionItem() { }

    public PrescriptionItem(int prescriptionId, int productId, int quantity,
        string? dosage, string? frequency, string? route)
    {
        PrescriptionId = prescriptionId;
        ProductId = productId;
        Quantity = quantity;
        Dosage = dosage;
        Frequency = frequency;
        Route = route;
    }
}