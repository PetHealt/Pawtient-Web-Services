using pawtient_project.Profiles.Domain.Models.Aggregates;
using pawtient_project.Profiles.Domain.Repositories;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace pawtient_project.Profiles.Infrastructure.Persistence.Repositories;

public class SpecializationRepository(AppDbContext context)
    : BaseRepository<Specialization>(context), ISpecializationRepository
{
}