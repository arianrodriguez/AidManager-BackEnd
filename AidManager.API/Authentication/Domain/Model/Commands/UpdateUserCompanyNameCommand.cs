namespace AidManager.API.Authentication.Domain.Model.Commands;

public record UpdateUserCompanyNameCommand(
    int UserId,
    string CompanyName
    );