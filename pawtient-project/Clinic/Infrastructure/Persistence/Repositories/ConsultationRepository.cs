using Microsoft.EntityFrameworkCore;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Clinic.Infrastructure.Persistence.Repositories;

public class ConsultationRepository(AppDbContext context)
    : BaseRepository<Consultation>(context), IConsultationRepository
{
    public async Task<IEnumerable<Consultation>> FindByMedicalRecordIdAsync(int medicalRecordId, CancellationToken cancellationToken = default)
    {
        return await Context.Consultations
            .Where(c => c.MedicalRecordId == medicalRecordId)
            .ToListAsync(cancellationToken);
    }
}