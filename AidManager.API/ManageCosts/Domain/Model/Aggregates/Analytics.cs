
using AidManager.API.ManageCosts.Domain.Model.Commands;

namespace AidManager.API.ManageCosts.Domain.Model.Aggregates;

public class Analytics
{
    public int Id { get; set; }
    
    public int ProjectId { get; set; }
    
    public List<int> Lines { get; set; }
    
    public List<int> Payments { get; set; }
    
    public List<int> Tasks { get; set; }
    
    public List<int> Progressbar { get; set; }
    
    public List<int> Status { get; set; }
    

    public Analytics()
    {
        
    }
    
    public Analytics(int id, int projectId, List<int> tasks, List<int> payments, List<int> progressbar, List<int> status, List<int> lines)
    {
        this.Id = id;
        this.ProjectId = projectId;
        this.Tasks = tasks;
        this.Payments = payments;
        this.Progressbar = progressbar;
        this.Status = status;
        this.Lines = lines;
    }
    
    public Analytics(CreateAnalyticsCommand command)
    {
        this.ProjectId = command.ProjectId;
        this.Tasks = command.Tasks;
        this.Payments = command.Payments;
        this.Progressbar = command.Progressbar;
        this.Status = command.Status;
        this.Lines = command.Lines;
    }
}