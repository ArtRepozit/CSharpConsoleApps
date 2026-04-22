using Artoodo.App;

namespace Artoodo.UI;

public class ConsoleMenu
{
    private readonly TodoService _service;
    public ConsoleMenu(TodoService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("1. View all tasks");
            Console.WriteLine("2. Add a new task");
            Console.WriteLine("3. Update task status");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");

            var choice = ConsoleInputHandler.ReadInt("Choose an option: ");
            switch (choice)
            {
                case 1:
                    ViewAllTasks();
                    break;
                case 2:
                    AddNewTask();
                    break;
                case 3:
                    UpdateTaskStatus();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void ViewAllTasks()
    {
        var tasks = _service.GetAllTasks;
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Name: {task.Name}, Status: {task.Status}");
        }
    }

    private void AddNewTask()
    {
        var name = ConsoleInputHandler.ReadNonEmpty("Enter task name: ");
        var description = ConsoleInputHandler.ReadNonEmpty("Enter task description: ");
        var dueDate = ConsoleInputHandler.ReadDate("Enter due date (e.g., 2024-12-31): ");
        var newTask = _service.AddTask(name, description, dueDate);
        Console.WriteLine($"Task added with ID: {newTask.Id}");
    }

    private void UpdateTaskStatus()
    {
        var id = ConsoleInputHandler.ReadInt("Enter task ID to update: ");
        var newStatus = ConsoleInputHandler.ReadTaskStatus("Select new status:");
        if (_service.UpdateTaskStatus(id, newStatus))
            Console.WriteLine("Task status updated successfully.");
        else
            Console.WriteLine("Task not found. Please try again.");
    }

    private void DeleteTask()
    {
        var id = ConsoleInputHandler.ReadInt("Enter task ID to delete: ");
        if (_service.DeleteTask(id))
            Console.WriteLine("Task deleted successfully.");
        else
            Console.WriteLine("Task not found. Please try again.");
    }
}