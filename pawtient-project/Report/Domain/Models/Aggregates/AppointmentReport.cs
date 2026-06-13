namespace pawtient_project.Report.Domain.Models.Aggregates;

public class AppointmentReport
{
    public int Id { get; private set; }
    public int ClinicId { get; private set; }
    public DateTime GeneratedAt { get; private set; }
    public DateOnly PeriodStart { get; private set; }
    public DateOnly PeriodEnd { get; private set; }
    public int TotalAppointments { get; private set; }
    public int CompletedAppointments { get; private set; }
    public int CancelledAppointments { get; private set; }
    public int NoShowAppointments { get; private set; }

    public AppointmentReport() { }

    public AppointmentReport(int clinicId, DateOnly periodStart, DateOnly periodEnd,
        int totalAppointments, int completedAppointments,
        int cancelledAppointments, int noShowAppointments)
    {
        ClinicId = clinicId;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
        TotalAppointments = totalAppointments;
        CompletedAppointments = completedAppointments;
        CancelledAppointments = cancelledAppointments;
        NoShowAppointments = noShowAppointments;
        GeneratedAt = DateTime.UtcNow;
    }
}