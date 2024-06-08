namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record GetUserResource(int Id, string FirstName, string LastName, int Age, string Email, string Phone, string Occupation, string Password, string ProfileImg, string Role, string CompanyName, string Bio);