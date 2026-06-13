using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using pawtient_project.Store.Domain.Models.Aggregates;
using pawtient_project.Store.Domain.Repositories;

namespace pawtient_project.Store.Infrastructure.Persistence.Repositories;

public class ProductCategoryRepository(AppDbContext context): BaseRepository<ProductCategory>(context), IProductCategoryRepository
{
}