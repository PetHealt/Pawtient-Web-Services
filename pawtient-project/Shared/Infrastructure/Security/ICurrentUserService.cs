namespace pawtient_project.Shared.Infrastructure.Security;

public interface ICurrentUserService
{
    int UserId { get; }
    Task<int> GetClinicIdAsync(CancellationToken cancellationToken = default);
}
