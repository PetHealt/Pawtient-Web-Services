using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pawtient_project.Shared.Infrastructure.Security;
using pawtient_project.Store.Application.CommandServices;
using pawtient_project.Store.Application.QueryServices;
using pawtient_project.Store.Interfaces.Rest.Resources;
using pawtient_project.Store.Interfaces.Rest.Transform;

namespace pawtient_project.Store.Interfaces.Rest.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/suppliers")]
public class SuppliersController(
    ISupplierCommandService commandService,
    ISupplierQueryService queryService,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var suppliers = await queryService.FindByClinicIdAsync(clinicId, cancellationToken);
        return Ok(suppliers.Select(SupplierResourceAssembler.ToResource));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplierResource resource, CancellationToken cancellationToken)
    {
        var supplier = await commandService.CreateAsync(resource, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { }, SupplierResourceAssembler.ToResource(supplier));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSupplierResource resource, CancellationToken cancellationToken)
    {
        var supplier = await commandService.UpdateAsync(id, resource, cancellationToken);
        return supplier is null ? NotFound() : Ok(SupplierResourceAssembler.ToResource(supplier));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        return await commandService.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
    }
}
