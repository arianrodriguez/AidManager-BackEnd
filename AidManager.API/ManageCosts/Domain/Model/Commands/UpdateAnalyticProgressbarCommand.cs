namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record UpdateAnalyticProgressbarCommand(
    int Id,
    List<int> Progressbar
    );