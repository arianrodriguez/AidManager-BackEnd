namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record CreateUserResource(string FirstName, string LastName, string Email, string Password, string ProfileImg, string Role, string CompanyName);