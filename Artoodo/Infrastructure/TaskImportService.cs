using Artoodo.Domain;
using YamlDotNet.Core;
public class TaskImportService
{
    public List<TodoTask> ImportTasksFromYaml(string filePath)
    {
        Console.WriteLine("Importing tasks from YAML...");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");
        }

        try
        {
            var yamlContent = File.ReadAllText(filePath);
            var deserializer = new YamlDotNet.Serialization.Deserializer();
            var tasks = deserializer.Deserialize<List<TodoTask>>(yamlContent) ?? new List<TodoTask>();

            return tasks
                .Where(task => !string.IsNullOrWhiteSpace(task.Name) && !string.IsNullOrWhiteSpace(task.Description))
                .ToList();
        }
        catch (YamlException ex)
        {
            throw new InvalidOperationException($"Error importing tasks from YAML: {ex.Message}");
        }
    }
}