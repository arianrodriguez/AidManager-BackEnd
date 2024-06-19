namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record CreateCompanyResource(string BrandName, string IdentificationCode, string Country, string Phone, int UserId);