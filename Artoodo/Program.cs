using Artoodo.UI;
using Artoodo.App;

namespace Artoodo;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the TODO list console app!");
        var service = new TodoService();
        var taskExportService = new TaskExportService();
        var taskImportService = new TaskImportService();
        var menu = new ConsoleMenu(service, taskExportService, taskImportService);
        menu.Run();
    }
}
