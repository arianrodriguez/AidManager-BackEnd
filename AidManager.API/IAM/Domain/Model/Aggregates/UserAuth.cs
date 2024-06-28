using System.Text.Json.Serialization;
using AidManager.API.Authentication.Domain.Model.Entities;

namespace AidManager.API.IAM.Domain.Model.Aggregates;

public class UserAuth(string username, string passwordHash)
{
    public UserAuth() : this(string.Empty, string.Empty) { }
    
    public int Id { get;  }

    public string Username { get; private set; } = username;
    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    public UserAuth UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    
    public UserAuth UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    
}