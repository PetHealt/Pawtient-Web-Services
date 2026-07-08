namespace pawtient_project.Appointment.Interfaces.Rest.Resources;

public record CreateAppointmentResource(
    string Patient,
    string Owner,
    DateTime Date,
    string Time,
    string Status,
    string? Reason,
    decimal Amount);
