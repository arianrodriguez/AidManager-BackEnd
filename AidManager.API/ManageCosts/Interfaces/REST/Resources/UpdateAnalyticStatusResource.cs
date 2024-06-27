namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record UpdateAnalyticStatusResource(
    int Id,
    List<int> Status
    );