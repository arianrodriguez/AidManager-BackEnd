namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record UpdateAnalyticCommand(int Id,string Title, string Description, double Cost, double Progress, int[] Current, int[] Expected);