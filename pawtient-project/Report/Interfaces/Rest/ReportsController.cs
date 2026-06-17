using Microsoft.AspNetCore.Mvc;
using pawtient_project.Report.Application.CommandServices;
using pawtient_project.Report.Application.QueryServices;
using pawtient_project.Report.Interfaces.Rest.Resources;
using pawtient_project.Report.Interfaces.Rest.Transform;

namespace pawtient_project.Report.Interfaces.Rest;

[ApiController]
[Route("api/v1")]
public class ReportsController : ControllerBase
{
    private readonly IReportCommandService _reportCommandService;
    private readonly IReportQueryService _reportQueryService;

    public ReportsController(IReportCommandService reportCommandService, IReportQueryService reportQueryService)
    {
        _reportCommandService = reportCommandService;
        _reportQueryService = reportQueryService;
    }

    [HttpGet("reports/summary")]
    public async Task<IActionResult> GetSummary([FromQuery] int clinicId)
    {
        var summary = await _reportQueryService.GenerateGeneralReportAsync(clinicId);
        return Ok(summary);
    }

    [HttpGet("invoices")]
    public async Task<IActionResult> GetInvoices([FromQuery] int clinicId)
    {
        var invoices = await _reportQueryService.GetInvoicesByClinicIdAsync(clinicId);
        var resources = invoices.Select(InvoiceResourceAssembler.ToResource);
        return Ok(resources);
    }

    [HttpPost("invoices")]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
    {
        var invoice = await _reportCommandService.CreateInvoiceAsync(command);
        return CreatedAtAction(nameof(GetInvoices), new { clinicId = invoice.ClinicId }, InvoiceResourceAssembler.ToResource(invoice));
    }

    [HttpDelete("invoices/{id:int}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var result = await _reportCommandService.DeleteInvoiceAsync(id);
        return result ? NoContent() : NotFound();
    }
}