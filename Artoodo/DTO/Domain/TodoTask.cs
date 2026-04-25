namespace Artoodo.Domain;
public class TodoTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }

    public TodoTask() { }
    public TodoTask(int id, string name, string description, DateTime dueDate, TaskStatus status = TaskStatus.NotStarted)
    {
        Id = id;
        Name = name;
        Description = description;
        DueDate = dueDate;
        Status = status;
    }
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
    OnHold
}