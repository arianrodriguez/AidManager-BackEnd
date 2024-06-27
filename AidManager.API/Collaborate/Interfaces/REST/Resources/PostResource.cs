using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Collaborate.Interfaces.REST.Resources;

public record PostResource(int Id, String Title, String Subject, String Description, DateTime CreatedAt, int Rating, int CompanyId, GetUserResource User);