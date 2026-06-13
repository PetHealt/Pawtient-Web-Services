using pawtient_project.Appointment.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;

namespace pawtient_project.Appointment.Domain.Repositories;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<IEnumerable<Schedule>> FindByVeterinarianIdAsync(int veterinarianId, CancellationToken cancellationToken = default);
}