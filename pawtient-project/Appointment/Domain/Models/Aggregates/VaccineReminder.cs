namespace pawtient_project.Appointment.Domain.Models.Aggregates;

public class VaccineReminder
{
    public int Id { get; private set; }
    public int VaccineId { get; private set; }
    public int ReminderId { get; private set; }

    public Reminder? Reminder { get; private set; }

    public VaccineReminder() { }

    public VaccineReminder(int vaccineId, int reminderId)
    {
        VaccineId = vaccineId;
        ReminderId = reminderId;
    }
}