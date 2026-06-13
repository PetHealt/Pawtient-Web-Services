using Microsoft.EntityFrameworkCore;
using pawtient_project.Appointment.Domain.Models.Aggregates;
using pawtient_project.Appointment.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Appointment.Infrastructure.Persistence.Repositories;

public class ScheduleRepository(AppDbContext context)
    : BaseRepository<Schedule>(context), IScheduleRepository
{
    public async Task<IEnumerable<Schedule>> FindByVeterinarianIdAsync(int veterinarianId, CancellationToken cancellationToken = default)
    {
        return await Context.Schedules
            .Where(s => s.VeterinarianId == veterinarianId)
            .ToListAsync(cancellationToken);
    }
}