namespace AidManager.API.Authentication.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string Password, string ProfileImg, string Role, string CompanyName);