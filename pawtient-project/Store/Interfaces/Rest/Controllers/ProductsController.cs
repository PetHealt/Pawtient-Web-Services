using Microsoft.AspNetCore.Mvc;
using pawtient_project.Store.Application.CommandServices;
using pawtient_project.Store.Application.QueryServices;
using pawtient_project.Store.Interfaces.Rest.Resources;
using pawtient_project.Store.Interfaces.Rest.Transform;

namespace pawtient_project.Store.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController(IProductCommandService cmd, IProductQueryService query) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int clinicId) {
        var products = await query.FindByClinicIdAsync(clinicId);
        return Ok(products.Select(ProductResourceAssembler.ToResource));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductResource res) {
        var product = await cmd.CreateAsync(res);
        return CreatedAtAction(nameof(GetAll), new { clinicId = product.ClinicId }, ProductResourceAssembler.ToResource(product));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductResource res) {
        var product = await cmd.UpdateAsync(id, res);
        return product == null ? NotFound() : Ok(ProductResourceAssembler.ToResource(product));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
        return await cmd.DeleteAsync(id) ? NoContent() : NotFound();
    }
}