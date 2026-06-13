using pawtient_project.Shared.Domain.Repositories;
using AppointmentEntity = pawtient_project.Appointment.Domain.Models.Aggregates.Appointment;

namespace pawtient_project.Appointment.Domain.Repositories;

public interface IAppointmentRepository : IBaseRepository<AppointmentEntity>
{
    Task<IEnumerable<AppointmentEntity>> FindByPetIdAsync(int petId, CancellationToken cancellationToken = default);
    Task<IEnumerable<AppointmentEntity>> FindByVeterinarianIdAsync(int veterinarianId, CancellationToken cancellationToken = default);
}