namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record AnalyticResource(int Id, string Title, string Description, double Cost, double Progress,int[] Current, int[] Expected);