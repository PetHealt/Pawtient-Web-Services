using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pawtient_project.IAM.Application.Internal.OutboundServices;
using pawtient_project.IAM.Domain.Models.Aggregates;
using pawtient_project.IAM.Domain.Repositories;
using pawtient_project.IAM.Interfaces.Rest.Resources;
using pawtient_project.Profiles.Domain.Models.Aggregates;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.IAM.Interfaces.Rest;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController(
    IUserRepository userRepository,
    IHashingService hashingService,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    AppDbContext context,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(resource.FullName) ||
            string.IsNullOrWhiteSpace(resource.Email) ||
            string.IsNullOrWhiteSpace(resource.Password) ||
            string.IsNullOrWhiteSpace(resource.ClinicName))
        {
            return BadRequest(new { message = "Todos los campos son obligatorios." });
        }

        if (await userRepository.ExistsByEmailAsync(resource.Email, cancellationToken))
        {
            return Conflict(new { message = "El correo ya está registrado." });
        }

        var role = string.IsNullOrWhiteSpace(resource.Role) ? "VETERINARIAN" : resource.Role.Trim().ToUpperInvariant();
        var user = new User(resource.FullName.Trim(), resource.Email.Trim(), hashingService.HashPassword(resource.Password), role);
        await userRepository.AddAsync(user, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        var clinic = new Profiles.Domain.Models.Aggregates.Clinic(user.Id, resource.ClinicName.Trim(), null, null, null);
        await context.Clinics.AddAsync(clinic, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        return Ok(ToAuthenticatedResource(user, clinic.Name));
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByEmailAsync(resource.Email.Trim(), cancellationToken);
        if (user is null || user.Status != "ACTIVE" || !hashingService.VerifyPassword(resource.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Correo o contraseña inválidos." });
        }

        var clinicName = await context.Clinics
            .Where(c => c.UserId == user.Id)
            .Select(c => c.Name)
            .FirstOrDefaultAsync(cancellationToken) ?? string.Empty;

        return Ok(ToAuthenticatedResource(user, clinicName));
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me(CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(currentUserService.UserId, cancellationToken);
        if (user is null) return NotFound();

        var clinicName = await context.Clinics
            .Where(c => c.UserId == user.Id)
            .Select(c => c.Name)
            .FirstOrDefaultAsync(cancellationToken) ?? string.Empty;

        return Ok(ToAuthenticatedResource(user, clinicName));
    }

    private AuthenticatedUserResource ToAuthenticatedResource(User user, string clinicName)
    {
        return new AuthenticatedUserResource(
            tokenService.GenerateToken(user),
            user.Id,
            user.FullName,
            user.Email,
            user.Role,
            clinicName,
            user.PlanName);
    }
}
