namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record UpdateAnalyticStatusCommand(
    int Id,
    List<int> Status
        );