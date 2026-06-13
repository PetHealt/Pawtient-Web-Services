using System.Text.Json.Serialization;

namespace pawtient_project.IAM.Domain.Models.Aggregates;

public class User
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    
    [JsonIgnore] 
    public string PasswordHash { get; private set; }
    
    public string Role { get; private set; }
    public string Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User() { }

    public User(string fullName, string email, string passwordHash, string role)
    {
        FullName = fullName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        Status = "ACTIVE";
        CreatedAt = DateTime.UtcNow;
    }
}