using Artoodo.Domain;
using YamlDotNet.Serialization;
using TaskStatus = Artoodo.Domain.TaskStatus;

public class TaskExportService
{
    public void ExportTasksAsYaml(IReadOnlyList<TodoTask> items)
    {
        Console.WriteLine("Exporting tasks as YAML...");

        var exportItems = items.Select(item => new TaskExportItem
        {
            Name = item.Name,
            Description = item.Description,
            DueDate = item.DueDate,
            Status = item.Status
        });

        var yaml = new SerializerBuilder().Build().Serialize(exportItems);
        var exportFilePath = Path.Combine(AppContext.BaseDirectory, "TmpBackups", $"tasks_export_{DateTime.Now:yyyyMMdd_HHmmss}.yaml");
        var exportDir = Path.GetDirectoryName(exportFilePath)!;
        
        Directory.CreateDirectory(exportDir);
        File.WriteAllText(exportFilePath, yaml);
        
        Console.WriteLine($"Export completed successfully. File saved to: {exportFilePath}");
    }

    private sealed class TaskExportItem
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime DueDate { get; init; }
        public TaskStatus Status { get; init; }
    }
}
