namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record UpdateAnalyticPaymentsCommand(
    int Id,
    List<int> Payments
    );