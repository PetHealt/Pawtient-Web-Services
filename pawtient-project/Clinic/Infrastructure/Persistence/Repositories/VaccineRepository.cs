using Microsoft.EntityFrameworkCore;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Clinic.Infrastructure.Persistence.Repositories;

public class VaccineRepository(AppDbContext context)
    : BaseRepository<Vaccine>(context), IVaccineRepository
{
    public async Task<IEnumerable<Vaccine>> FindByMedicalRecordIdAsync(int medicalRecordId, CancellationToken cancellationToken = default)
    {
        return await Context.Vaccines
            .Where(v => v.MedicalRecordId == medicalRecordId)
            .ToListAsync(cancellationToken);
    }
}