using Microsoft.EntityFrameworkCore;
using pawtient_project.Appointment.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using AppointmentEntity = pawtient_project.Appointment.Domain.Models.Aggregates.Appointment;

namespace pawtient_project.Appointment.Infrastructure.Persistence.Repositories;

public class AppointmentRepository(AppDbContext context)
    : BaseRepository<AppointmentEntity>(context), IAppointmentRepository
{
    public async Task<IEnumerable<AppointmentEntity>> FindByPetIdAsync(int petId, CancellationToken cancellationToken = default)
    {
        return await Context.Appointments
            .Where(a => a.PetId == petId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<AppointmentEntity>> FindByVeterinarianIdAsync(int veterinarianId, CancellationToken cancellationToken = default)
    {
        return await Context.Appointments
            .Where(a => a.VeterinarianId == veterinarianId)
            .ToListAsync(cancellationToken);
    }
}