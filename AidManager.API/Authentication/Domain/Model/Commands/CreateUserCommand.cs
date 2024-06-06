namespace AidManager.API.Authentication.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, int Age, string Email, string Phone, string Occupation, string Password, string ProfileImg, string Role,
    string CompanyName, string Bio);