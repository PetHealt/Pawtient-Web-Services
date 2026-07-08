namespace pawtient_project.IAM.Infrastructure.Tokens.Jwt;

public class TokenSettings
{
    public string Secret { get; set; } = string.Empty;
    public int ExpirationDays { get; set; } = 7;
}
