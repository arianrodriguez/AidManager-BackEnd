namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record CreateAnalyticResource(string Title, string Description, double Cost, double Progress, int[] Current, int[] Expected);