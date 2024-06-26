namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record UpdateAnalyticLinesCommand(
    int Id,
    List<int> Lines
);