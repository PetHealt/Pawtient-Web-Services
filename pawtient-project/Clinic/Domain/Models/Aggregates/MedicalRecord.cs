namespace pawtient_project.Clinic.Domain.Models.Aggregates;

public class MedicalRecord
{
    public int Id { get; private set; }
    public int PetId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? Anamnesis { get; private set; }

    public Pet? Pet { get; private set; }

    public MedicalRecord() { }

    public MedicalRecord(int petId, string? anamnesis)
    {
        PetId = petId;
        Anamnesis = anamnesis;
        CreatedAt = DateTime.UtcNow;
    }
}