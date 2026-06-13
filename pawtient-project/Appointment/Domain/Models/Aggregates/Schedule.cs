namespace pawtient_project.Appointment.Domain.Models.Aggregates;

public class Schedule
{
    public int Id { get; private set; }
    public int VeterinarianId { get; private set; }
    public int ClinicId { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public bool IsAvailable { get; private set; }

    public Schedule() { }

    public Schedule(int veterinarianId, int clinicId, DateOnly date,
        TimeOnly startTime, TimeOnly endTime)
    {
        VeterinarianId = veterinarianId;
        ClinicId = clinicId;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        IsAvailable = true;
    }
}