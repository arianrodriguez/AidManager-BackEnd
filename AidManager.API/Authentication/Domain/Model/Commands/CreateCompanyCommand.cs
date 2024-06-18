namespace AidManager.API.Authentication.Domain.Model.Commands;

public record CreateCompanyCommand(string BrandName, string IdentificationCode, string Country, string Phone, int UserId);