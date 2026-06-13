using Microsoft.EntityFrameworkCore;
using pawtient_project.Appointment.Domain.Models.Aggregates;
using pawtient_project.Appointment.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Appointment.Infrastructure.Persistence.Repositories;

public class ReminderRepository(AppDbContext context)
    : BaseRepository<Reminder>(context), IReminderRepository
{
    public async Task<IEnumerable<Reminder>> FindByAppointmentIdAsync(int appointmentId, CancellationToken cancellationToken = default)
    {
        return await Context.Reminders
            .Where(r => r.AppointmentId == appointmentId)
            .ToListAsync(cancellationToken);
    }
}