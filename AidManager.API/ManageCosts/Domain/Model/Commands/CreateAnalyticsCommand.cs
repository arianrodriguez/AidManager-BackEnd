namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record CreateAnalyticsCommand(
    int ProjectId,
    List<int> Tasks,
    List<int> Payments,
    List<int> Progressbar,
    List<int> Status,
    List<int> Lines
);