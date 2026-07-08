using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Interfaces.Rest.Resources;

namespace pawtient_project.Report.Interfaces.Rest.Transform;

public static class InvoiceResourceAssembler
{
    public static InvoiceResource ToResource(Invoice invoice)
    {
        return new InvoiceResource(
            invoice.Id,
            invoice.Date,
            invoice.Patient,
            invoice.Client,
            invoice.Amount);
    }
}
