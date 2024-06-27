namespace AidManager.API.ManageCosts.Interfaces.REST.Resources;

public record UpdateAnalyticPaymentsResource(
    int Id,
    List<int> Payments
    );