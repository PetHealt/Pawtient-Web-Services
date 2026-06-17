using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Interfaces.Rest.Resources;

namespace pawtient_project.Report.Interfaces.Rest.Transform;

public class InvoiceResourceAssembler
{
    public static InvoiceResource ToResource(Invoice invoice) => new InvoiceResource(
        invoice.Id,
        invoice.ClinicId,
        invoice.AppointmentId,
        invoice.ConsultationId,
        invoice.PetName,
        invoice.OwnerName,
        invoice.Amount,
        invoice.Date,
        invoice.Status,
        invoice.Notes
    );
}