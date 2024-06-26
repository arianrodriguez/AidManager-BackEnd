namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record CreateAnalyticsResource(
    int ProjectId,
    List<int> Lines,
    List<int> Payments,
    List<int> Progressbar,
    List<int> Status,
    List<int> Tasks
    );