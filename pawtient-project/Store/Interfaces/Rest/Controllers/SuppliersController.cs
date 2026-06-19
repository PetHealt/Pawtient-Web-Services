using Microsoft.AspNetCore.Mvc;
using pawtient_project.Store.Application.CommandServices;
using pawtient_project.Store.Application.QueryServices;
using pawtient_project.Store.Interfaces.Rest.Resources;
using pawtient_project.Store.Interfaces.Rest.Transform;

namespace pawtient_project.Store.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/suppliers")]
public class SuppliersController(ISupplierCommandService cmd, ISupplierQueryService query) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int clinicId) {
        var suppliers = await query.FindByClinicIdAsync(clinicId);
        return Ok(suppliers.Select(SupplierResourceAssembler.ToResource));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplierResource res) {
        var supplier = await cmd.CreateAsync(res);
        return CreatedAtAction(nameof(GetAll), new { clinicId = supplier.ClinicId }, SupplierResourceAssembler.ToResource(supplier));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSupplierResource res) {
        var supplier = await cmd.UpdateAsync(id, res);
        return supplier == null ? NotFound() : Ok(SupplierResourceAssembler.ToResource(supplier));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
        return await cmd.DeleteAsync(id) ? NoContent() : NotFound();
    }
}