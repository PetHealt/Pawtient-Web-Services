namespace pawtient_project.Appointment.Domain.Models.Aggregates;

public class Appointment
{
    public int Id { get; private set; }
    public int? ClinicId { get; private set; }
    public int? PetId { get; private set; }
    public int? VeterinarianId { get; private set; }
    public int? ScheduleId { get; private set; }
    public DateTime Date { get; private set; }
    public string Time { get; private set; }
    public string Patient { get; private set; }
    public string Owner { get; private set; }
    public string Status { get; private set; }
    public string? Reason { get; private set; }
    public string Type { get; private set; }
    public decimal Amount { get; private set; }
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
        Time = date.ToString("HH:mm");
        Patient = string.Empty;
        Owner = string.Empty;
        Amount = 0;
        CreatedAt = DateTime.UtcNow;
    }

    public Appointment(int clinicId, string patient, string owner, DateTime date, string time, string status, string? reason, decimal amount)
    {
        ClinicId = clinicId;
        Patient = patient;
        Owner = owner;
        Date = date;
        Time = time;
        Status = status;
        Reason = reason;
        Amount = amount;
        Type = "CONSULTATION";
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string patient, string owner, DateTime date, string time, string status, string? reason, decimal amount)
    {
        Patient = patient;
        Owner = owner;
        Date = date;
        Time = time;
        Status = status;
        Reason = reason;
        Amount = amount;
    }
}
