namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record GetCompanyResource(int Id, string BrandName, string IdentificationCode, string Country, string Phone, int UserId);