using Artoodo.Domain;
using TaskStatus = Artoodo.Domain.TaskStatus;

namespace Artoodo.App;
public class TodoService
{

 // to toggle multi line comment, select the lines and press Ctrl + K + C to comment and Ctrl + K + U to uncomment
 // or you can use option + shift + a to toggle comment in one step

    private readonly List<TodoTask> _tasks = new();
    public int nextTaskId = 1;
    
    public IReadOnlyList<TodoTask> GetAllTasks => _tasks.AsReadOnly();

    public TodoTask? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }
    
    public TodoTask AddTask(string name, string description, DateTime dueDate, TaskStatus status = TaskStatus.NotStarted)
    {
        var newTask = new TodoTask(nextTaskId++, name, description, dueDate, status);
        _tasks.Add(newTask);
        return newTask;
    }

    public bool UpdateTaskStatus(int id, TaskStatus newStatus)
    {
        var task = GetTaskById(id);
        if (task == null)            
            return false;
        task.Status = newStatus;
        return true;
    }

    public bool DeleteTask(int id)
    {
        var task = GetTaskById(id);
        if (task == null)
            return false;
        _tasks.Remove(task);
        return true;
    }
}