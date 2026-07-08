using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pawtient_project.Clinic.Application.CommandServices;
using pawtient_project.Clinic.Application.QueryServices;
using pawtient_project.Clinic.Interfaces.Rest.Resources;
using pawtient_project.Clinic.Interfaces.Rest.Transform;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Clinic.Interfaces.Rest;

[Authorize]
[ApiController]
[Route("api/v1/pets")]
public class PetsController(
    IPetCommandService petCommandService,
    IPetQueryService petQueryService,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var pets = await petQueryService.GetByClinicIdAsync(clinicId, cancellationToken);
        return Ok(pets.Select(PetResourceAssembler.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var pet = await petQueryService.GetByIdAsync(id, cancellationToken);
        if (pet is null) return NotFound();
        return Ok(PetResourceAssembler.ToResource(pet));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePetResource resource, CancellationToken cancellationToken)
    {
        var pet = await petCommandService.CreateAsync(resource, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, PetResourceAssembler.ToResource(pet));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePetResource resource, CancellationToken cancellationToken)
    {
        var pet = await petCommandService.UpdateAsync(id, resource, cancellationToken);
        if (pet is null) return NotFound();
        return Ok(PetResourceAssembler.ToResource(pet));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await petCommandService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
