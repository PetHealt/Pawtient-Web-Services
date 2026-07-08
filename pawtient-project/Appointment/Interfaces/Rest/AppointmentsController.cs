using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pawtient_project.Appointment.Interfaces.Rest.Resources;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Appointment.Interfaces.Rest;

[Authorize]
[ApiController]
[Route("api/v1/appointments")]
public class AppointmentsController(
    AppDbContext context,
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var appointments = await context.Appointments
            .Where(a => a.ClinicId == clinicId)
            .OrderBy(a => a.Date)
            .Select(a => ToResource(a))
            .ToListAsync(cancellationToken);

        return Ok(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentResource resource, CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var appointment = new Domain.Models.Aggregates.Appointment(
            clinicId,
            resource.Patient,
            resource.Owner,
            resource.Date,
            resource.Time,
            resource.Status,
            resource.Reason,
            resource.Amount);

        await context.Appointments.AddAsync(appointment, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { }, ToResource(appointment));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAppointmentResource resource, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments.FindAsync(new object[] { id }, cancellationToken);
        if (appointment is null) return NotFound();

        appointment.Update(resource.Patient, resource.Owner, resource.Date, resource.Time, resource.Status, resource.Reason, resource.Amount);
        context.Appointments.Update(appointment);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Ok(ToResource(appointment));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var appointment = await context.Appointments.FindAsync(new object[] { id }, cancellationToken);
        if (appointment is null) return NotFound();

        context.Appointments.Remove(appointment);
        await unitOfWork.CompleteAsync(cancellationToken);
        return NoContent();
    }

    private static AppointmentResource ToResource(Domain.Models.Aggregates.Appointment appointment)
    {
        return new AppointmentResource(
            appointment.Id,
            appointment.Date,
            appointment.Time,
            appointment.Patient,
            appointment.Owner,
            appointment.Status,
            appointment.Reason,
            appointment.Amount);
    }
}
