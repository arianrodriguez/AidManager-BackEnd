namespace AidManager.API.Authentication.Domain.Model.Entities;

public class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string ProfileImg { get; private set; }
    public string Role { get; private set; }
    public string CompanyName { get; private set; }
    
    public User(string FirstName, string LastName, string Email, string Password, string ProfileImg, string Role,
        string CompanyName)
    {
        
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.Password = Password;
        this.ProfileImg = ProfileImg;
        this.Role = Role;
        this.CompanyName = CompanyName;
    }
}