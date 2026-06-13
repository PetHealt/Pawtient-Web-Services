using Microsoft.EntityFrameworkCore;
using pawtient_project.Clinic.Domain.Models.Aggregates;
using pawtient_project.Clinic.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Clinic.Infrastructure.Persistence.Repositories;

public class MedicalRecordRepository(AppDbContext context)
    : BaseRepository<MedicalRecord>(context), IMedicalRecordRepository
{
    public async Task<MedicalRecord?> FindByPetIdAsync(int petId, CancellationToken cancellationToken = default)
    {
        return await Context.MedicalRecords
            .FirstOrDefaultAsync(m => m.PetId == petId, cancellationToken);
    }
}