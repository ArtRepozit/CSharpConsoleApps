// See https://aka.ms/new-console-template for more information
using Artoodo.UI;
using Artoodo.App;

namespace Artoodo;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the TODO list console app!");
        var service = new TodoService();
        var menu = new ConsoleMenu(service);
        menu.Run();

    }
}

