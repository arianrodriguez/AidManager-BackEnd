namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record UpdateUserCompanyNameResource(
    int UserId,
    string CompanyName
    );