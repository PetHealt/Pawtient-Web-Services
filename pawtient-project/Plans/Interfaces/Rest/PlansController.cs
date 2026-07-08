using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pawtient_project.IAM.Domain.Repositories;
using pawtient_project.Plans.Interfaces.Rest.Resources;
using pawtient_project.Shared.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Plans.Interfaces.Rest;

[ApiController]
[Route("api/v1/plans")]
public class PlansController(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService) : ControllerBase
{
    private static readonly PlanResource[] Plans =
    [
        new("Paw Basic", "Para Veterinarios Independientes", 29.99m),
        new("Paw Care", "Para Clínicas en crecimiento", 59.99m),
        new("Paw Pro", "Para Hospitales Veterinarios", 99.99m)
    ];

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetPlans()
    {
        return Ok(Plans);
    }

    [HttpPut("current")]
    [Authorize]
    public async Task<IActionResult> SelectPlan([FromBody] SelectPlanResource resource, CancellationToken cancellationToken)
    {
        if (!Plans.Any(plan => plan.Name == resource.PlanName)) return BadRequest(new { message = "Plan inválido." });

        var user = await userRepository.FindByIdAsync(currentUserService.UserId, cancellationToken);
        if (user is null) return NotFound();

        user.UpdatePlan(resource.PlanName);
        userRepository.Update(user);
        await unitOfWork.CompleteAsync(cancellationToken);
        return NoContent();
    }
}
