namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record UpdateAnalyticResource(int Id, string Title, string Description, double Cost, double Progress, int[] Current, int[] Expected);