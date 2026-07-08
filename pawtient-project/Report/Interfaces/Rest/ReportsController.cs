using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pawtient_project.Report.Application.CommandServices;
using pawtient_project.Report.Application.QueryServices;
using pawtient_project.Report.Interfaces.Rest.Resources;
using pawtient_project.Report.Interfaces.Rest.Transform;
using pawtient_project.Shared.Infrastructure.Security;

namespace pawtient_project.Report.Interfaces.Rest;

[Authorize]
[ApiController]
[Route("api/v1")]
public class ReportsController(
    IReportCommandService reportCommandService,
    IReportQueryService reportQueryService,
    ICurrentUserService currentUserService) : ControllerBase
{
    [HttpGet("reports/summary")]
    public async Task<IActionResult> GetSummary(CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var summary = await reportQueryService.GenerateGeneralReportAsync(clinicId, cancellationToken);
        return Ok(summary);
    }

    [HttpGet("invoices")]
    public async Task<IActionResult> GetInvoices(CancellationToken cancellationToken)
    {
        var clinicId = await currentUserService.GetClinicIdAsync(cancellationToken);
        var invoices = await reportQueryService.GetInvoicesByClinicIdAsync(clinicId, cancellationToken);
        return Ok(invoices.Select(InvoiceResourceAssembler.ToResource));
    }

    [HttpPost("invoices")]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command, CancellationToken cancellationToken)
    {
        var invoice = await reportCommandService.CreateInvoiceAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetInvoices), new { }, InvoiceResourceAssembler.ToResource(invoice));
    }
}
