namespace Artoodo.Domain;
public class TodoTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }

    public TodoTask(int id, string name, string description, DateTime dueDate)
    {

        Id = id;
        Name = name;
        Description = description;
        DueDate = dueDate;
        Status = TaskStatus.NotStarted;
    }
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
    OnHold
}