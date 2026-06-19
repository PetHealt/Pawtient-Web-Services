using Microsoft.AspNetCore.Mvc;
using pawtient_project.IAM.Application.CommandServices;
using pawtient_project.IAM.Application.QueryServices;
using pawtient_project.IAM.Domain.Models.Commands;
using pawtient_project.IAM.Domain.Models.Queries;

namespace pawtient_project.IAM.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IUserCommandService commandService, IUserQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await queryService.Handle(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await queryService.Handle(new GetUserByIdQuery(id));
        if (user is null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var user = await commandService.Handle(command);
        if (user is null) return BadRequest("El usuario ya existe.");
        
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}