using ConsoleApp1.Domain;

namespace ConsoleApp1.UI;

public static class ConsoleInputHandler
{
    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                return result;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var text = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(text))
                return text.Trim();
            
            Console.WriteLine("Invalid input. Please enter a non-empty string.");
        }
    }

    public static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime result))
                return result;
            Console.WriteLine("Invalid input. Please enter a valid date.");
        }
    }

    public static Domain.TaskStatus ReadTaskStatus(string prompt)
    {
        Console.WriteLine(prompt);
        Console.WriteLine("0 - NotStarted, 1 - InProgress, 2 - Completed, 3 - OnHold");

        while (true)
        {
            var num = ReadInt("Pick a status: ");
            if (Enum.IsDefined(typeof(Domain.TaskStatus), num))
                return (Domain.TaskStatus)num;

            Console.WriteLine("No such status. Please try again.");
        }
    }
}