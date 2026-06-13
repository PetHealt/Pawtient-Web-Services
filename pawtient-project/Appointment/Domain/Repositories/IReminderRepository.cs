using pawtient_project.Appointment.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Appointment.Domain.Repositories;

public interface IReminderRepository : IBaseRepository<Reminder>
{
    Task<IEnumerable<Reminder>> FindByAppointmentIdAsync(int appointmentId, CancellationToken cancellationToken = default);
}