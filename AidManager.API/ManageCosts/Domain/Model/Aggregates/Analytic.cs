namespace AidManager.API.ManageCosts.Domain.Model.Aggregates;

public class Analytic
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public int Cost { get; private set; }
    public int Progress { get; private set; }
    public string Description { get; private set; }
    
    public Array values { get; private set; }

    protected Analytic()
    {
        this.Title = "nothing";
        this.Cost = 0;
        this.Progress = 0;
        this.Description = "nothing";
        
    }
    //
    // public Analytic(CreateAnaliticCommand command)
    // {
    //     this.Title = command.Title;
    //     this.Cost = command.Cost;
    //     this.Progress = command.Progress;
    //     this.Description = command.Description;
    // }
}