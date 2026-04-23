using Artoodo.Domain;
using YamlDotNet.Serialization;

public class TaskExportService
{
    public void ExportTasksAsYaml(IReadOnlyList<TodoTask> items)
    {
        Console.WriteLine("Exporting tasks as YAML...");

        var yaml = new Serializer().Serialize(items);
        var exportFilePath = Path.Combine(AppContext.BaseDirectory, "TmpBackups", $"tasks_export_{DateTime.Now:yyyyMMdd_HHmmss}.yaml");
        var exportDir = Path.GetDirectoryName(exportFilePath)!;
        
        Directory.CreateDirectory(exportDir);
        File.WriteAllText(exportFilePath, yaml);
        
        Console.WriteLine($"Export completed successfully. File saved to: {exportFilePath}");
    }
}
