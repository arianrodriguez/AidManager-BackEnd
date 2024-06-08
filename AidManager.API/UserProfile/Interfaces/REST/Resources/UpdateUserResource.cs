namespace AidManager.API.UserProfile.Interfaces.REST.Resources;

public record UpdateUserResource(string FirstName, string LastName, int Age, string Phone, string Occupation, string Password, string ProfileImg, string Role, string CompanyName, string Bio);