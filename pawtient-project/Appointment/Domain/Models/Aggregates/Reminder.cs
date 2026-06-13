namespace pawtient_project.Appointment.Domain.Models.Aggregates;

public class Reminder
{
    public int Id { get; private set; }
    public int? AppointmentId { get; private set; }
    public string? Message { get; private set; }
    public DateTime? ScheduledAt { get; private set; }
    public DateTime? SentAt { get; private set; }
    public string Channel { get; private set; }

    public Appointment? Appointment { get; private set; }

    public Reminder() { }

    public Reminder(int? appointmentId, string? message, DateTime? scheduledAt, string channel)
    {
        AppointmentId = appointmentId;
        Message = message;
        ScheduledAt = scheduledAt;
        Channel = channel;
    }
}