using Artoodo.App;

namespace Artoodo.UI;

public class ConsoleMenu
{
    private readonly TodoService _service;
    private readonly TaskExportService _taskExportService;
    private readonly TaskImportService _taskImportService;
    public ConsoleMenu(TodoService service, TaskExportService taskExportService, TaskImportService taskImportService)
    {
        _service = service;
        _taskExportService = taskExportService;
        _taskImportService = taskImportService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("1. View all tasks");
            Console.WriteLine("2. Add a new task");
            Console.WriteLine("3. Update task status");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Export tasks to YAML");
            Console.WriteLine("6. Import tasks from YAML");
            Console.WriteLine("7. Exit");

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
                    ExportTasks();
                    break;
                case 6:
                    ImportTasks();
                    break;
                case 7:
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

    private void ExportTasks()
    {
        _taskExportService.ExportTasksAsYaml(_service.GetAllTasks);
    }

    private void ImportTasks()
    {
        var filePath = ConsoleInputHandler.ReadNonEmpty("Enter the path to the YAML file to import: ");
        var importedTasks = _taskImportService.ImportTasksFromYaml(filePath);
        if (importedTasks.Count > 0)
        {
            foreach (var task in importedTasks)
            {
                _service.AddTask(task.Name, task.Description, task.DueDate, task.Status);
            }
            Console.WriteLine($"Successfully imported {importedTasks.Count} tasks.");
        }
        else
        {
            Console.WriteLine("No tasks were imported because the file was empty or an error occurred.");
        }
    }
}
