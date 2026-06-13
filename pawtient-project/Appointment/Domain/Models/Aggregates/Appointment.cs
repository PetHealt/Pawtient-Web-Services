namespace pawtient_project.Appointment.Domain.Models.Aggregates;

public class Appointment
{
    public int Id { get; private set; }
    public int PetId { get; private set; }
    public int VeterinarianId { get; private set; }
    public int? ScheduleId { get; private set; }
    public DateTime Date { get; private set; }
    public string Status { get; private set; }
    public string? Reason { get; private set; }
    public string Type { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Schedule? Schedule { get; private set; }

    public Appointment() { }

    public Appointment(int petId, int veterinarianId, int? scheduleId,
        DateTime date, string? reason, string type)
    {
        PetId = petId;
        VeterinarianId = veterinarianId;
        ScheduleId = scheduleId;
        Date = date;
        Reason = reason;
        Type = type;
        Status = "REQUESTED";
        CreatedAt = DateTime.UtcNow;
    }
}