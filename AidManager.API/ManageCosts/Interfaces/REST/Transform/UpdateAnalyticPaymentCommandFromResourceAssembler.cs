using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class UpdateAnalyticPaymentCommandFromResourceAssembler
{
    public static UpdateAnalyticPaymentsCommand ToCommandFromResource(int id, UpdateAnalyticPaymentsResource resource)
    {
        return new UpdateAnalyticPaymentsCommand(
            id,
            resource.Payments
        );
    }
}