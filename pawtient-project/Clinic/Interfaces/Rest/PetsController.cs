using Microsoft.AspNetCore.Mvc;
using pawtient_project.Clinic.Application.CommandServices;
using pawtient_project.Clinic.Application.QueryServices;
using pawtient_project.Clinic.Interfaces.Rest.Resources;
using pawtient_project.Clinic.Interfaces.Rest.Transform;

namespace pawtient_project.Clinic.Interfaces.Rest;

[ApiController]
[Route("api/v1/pets")]
public class PetsController : ControllerBase
{
    private readonly IPetCommandService _petCommandService;
    private readonly IPetQueryService _petQueryService;

    public PetsController(IPetCommandService petCommandService, IPetQueryService petQueryService)
    {
        _petCommandService = petCommandService;
        _petQueryService = petQueryService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pet = await _petQueryService.GetByIdAsync(id);
        if (pet is null) return NotFound();
        return Ok(PetResourceAssembler.ToResource(pet));
    }

    [HttpGet("clinic/{clinicId:int}")]
    public async Task<IActionResult> GetByClinicId(int clinicId)
    {
        var pets = await _petQueryService.GetByClinicIdAsync(clinicId);
        var resources = pets.Select(PetResourceAssembler.ToResource);
        return Ok(resources);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePetResource resource)
    {
        var pet = await _petCommandService.CreateAsync(resource);
        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, PetResourceAssembler.ToResource(pet));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePetResource resource)
    {
        var pet = await _petCommandService.UpdateAsync(id, resource);
        if (pet is null) return NotFound();
        return Ok(PetResourceAssembler.ToResource(pet));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _petCommandService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}