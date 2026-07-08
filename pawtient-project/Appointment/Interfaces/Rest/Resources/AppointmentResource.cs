namespace pawtient_project.Appointment.Interfaces.Rest.Resources;

public record AppointmentResource(
    int Id,
    DateTime Date,
    string Time,
    string Patient,
    string Owner,
    string Status,
    string? Reason,
    decimal Amount);
