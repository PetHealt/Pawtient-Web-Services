using Microsoft.EntityFrameworkCore;
using pawtient_project.Report.Domain.Models.Aggregates;
using pawtient_project.Report.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Report.Infrastructure.Persistence.Repositories;

public class ConsultationReportRepository(AppDbContext context)
    : BaseRepository<ConsultationReport>(context), IConsultationReportRepository
{
    public async Task<IEnumerable<ConsultationReport>> FindByClinicIdAsync(int clinicId, CancellationToken cancellationToken = default)
    {
        return await Context.ConsultationReports
            .Where(r => r.ClinicId == clinicId)
            .ToListAsync(cancellationToken);
    }
}