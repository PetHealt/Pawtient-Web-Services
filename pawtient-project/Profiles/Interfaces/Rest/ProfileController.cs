using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pawtient_project.IAM.Domain.Repositories;
using pawtient_project.Profiles.Interfaces.Rest.Resources;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Profiles.Interfaces.Rest;

[Authorize]
[ApiController]
[Route("api/v1")]
public class ProfileController(
    IUserRepository userRepository,
    AppDbContext context,
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile(CancellationToken cancellationToken)
    {
        var result = await LoadProfileAsync(cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileResource resource, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(currentUserService.UserId, cancellationToken);
        if (user is null) return NotFound();

        var clinic = await context.Clinics.FirstOrDefaultAsync(c => c.UserId == user.Id, cancellationToken);
        if (clinic is null) return NotFound();

        user.UpdateProfile(resource.FullName, resource.Email);
        clinic.UpdateName(resource.ClinicName);
        userRepository.Update(user);
        context.Clinics.Update(clinic);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Ok(await LoadProfileAsync(cancellationToken));
    }

    [HttpDelete("account")]
    public async Task<IActionResult> DeleteAccount(CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(currentUserService.UserId, cancellationToken);
        if (user is null) return NotFound();

        user.Deactivate();
        userRepository.Update(user);
        await unitOfWork.CompleteAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard(CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(currentUserService.UserId, cancellationToken);
        if (user is null) return NotFound();

        var clinic = await context.Clinics.FirstOrDefaultAsync(c => c.UserId == user.Id, cancellationToken);
        if (clinic is null) return NotFound();

        var pending = await context.Appointments
            .CountAsync(a => a.ClinicId == clinic.Id && a.Status == "Pendiente", cancellationToken);

        return Ok(new DashboardResource(user.FullName, clinic.Name, pending, user.PlanName));
    }

    private async Task<ProfileResource?> LoadProfileAsync(CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(currentUserService.UserId, cancellationToken);
        if (user is null) return null;

        var clinicName = await context.Clinics
            .Where(c => c.UserId == user.Id)
            .Select(c => c.Name)
            .FirstOrDefaultAsync(cancellationToken);

        return new ProfileResource(user.FullName, user.Email, user.Role, clinicName ?? string.Empty, user.PlanName);
    }
}
