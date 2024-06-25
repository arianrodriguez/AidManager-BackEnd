using AidManager.API.ManageTasks.Domain.Model.Commands;

namespace AidManager.API.ManageTasks.Domain.Model.Aggregates;

public class TaskItem
{
    public int Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public DateTime DueDate { get; private set; }
    
    public int ProjectId { get; private set; }
    
   public string State {get; private set;}
    
   public string Assignee {get; private set;}
   
    protected TaskItem()
    {
        this.Title = string.Empty;
        this.Description = string.Empty;
        this.DueDate = DateTime.Now;
        this.ProjectId = 0;
        this.State = "ToDo";
        this.Assignee = string.Empty;
    }

    public TaskItem(CreateTaskCommand command)
    {
        this.Title = command.Title;
        this.Description = command.Description;
        this.DueDate = command.DueDate;
        this.ProjectId = command.ProjectId;
        this.State = command.State;
        this.Assignee = command.Assigned;

    }
    
    public void UpdateTask(UpdateTaskCommand command)
    {
        this.Title = command.Title;
        this.Description = command.Description;
        this.DueDate = command.DueDate;
        this.State = command.State;
        this.Assignee = command.Assigned;
    }
    
    
    
}