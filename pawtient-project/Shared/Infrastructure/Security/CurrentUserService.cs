using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using pawtient_project.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace pawtient_project.Shared.Infrastructure.Security;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor, AppDbContext context) : ICurrentUserService
{
    public int UserId
    {
        get
        {
            var value = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(value, out var userId)) throw new UnauthorizedAccessException("Usuario no autenticado.");
            return userId;
        }
    }

    public async Task<int> GetClinicIdAsync(CancellationToken cancellationToken = default)
    {
        var clinic = await context.Clinics.FirstOrDefaultAsync(c => c.UserId == UserId, cancellationToken);
        if (clinic is null) throw new InvalidOperationException("El usuario no tiene clínica asociada.");
        return clinic.Id;
    }
}
