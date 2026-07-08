namespace pawtient_project.Profiles.Interfaces.Rest.Resources;

public record DashboardResource(
    string FullName,
    string ClinicName,
    int PendingAppointments,
    string Plan);
