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
[Route("api/v1/products")]
public class ProductsController(
    IProductCommandService commandService,
    IProductQueryService queryService,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var products = await queryService.FindByClinicIdAsync(clinicId, cancellationToken);
        return Ok(products.Select(ProductResourceAssembler.ToResource));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductResource resource, CancellationToken cancellationToken)
    {
        var product = await commandService.CreateAsync(resource, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { }, ProductResourceAssembler.ToResource(product));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductResource resource, CancellationToken cancellationToken)
    {
        var product = await commandService.UpdateAsync(id, resource, cancellationToken);
        return product is null ? NotFound() : Ok(ProductResourceAssembler.ToResource(product));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        return await commandService.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
    }
}
