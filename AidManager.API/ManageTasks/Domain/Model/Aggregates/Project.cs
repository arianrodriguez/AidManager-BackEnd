using AidManager.API.ManageTasks.Domain.Model.Commands;

namespace AidManager.API.ManageTasks.Domain.Model.Aggregates;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string CompanyId { get; set; }
    public Project() { }
    public Project(CreateProjectCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
        this.ImageUrl = command.ImageUrl;
        this.CompanyId = command.CompanyId;
    }
}