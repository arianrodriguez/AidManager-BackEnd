namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record UpdateAnalyticLinesResource(
    int Id,
    List<int> Lines
    );