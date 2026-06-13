using Microsoft.AspNetCore.Mvc;
using pawtient_project.IAM.Domain.Repositories;

namespace pawtient_project.IAM.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await userRepository.ListAsync(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByIdAsync(id, cancellationToken);
        if (user is null) return NotFound();
        return Ok(user);
    }
}