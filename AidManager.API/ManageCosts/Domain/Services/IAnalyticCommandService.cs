using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Model.Commands;

namespace AidManager.API.ManageCosts.Domain.Services;

public interface IAnalyticCommandService
{
    Task<Analytic> Handle(CreateAnalyticCommand command);
}