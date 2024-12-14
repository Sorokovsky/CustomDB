using System.Text.Json;
using Database.Contracts;

namespace Database.Services;

public class FileService<T> : IStorage<T>
{
    private readonly string _filePath;

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(T data)
    {
        var mode = FileMode.Truncate;
        if (File.Exists(_filePath) == false) mode = FileMode.OpenOrCreate;

        using var stream = new StreamWriter(File.Open(_filePath, mode));
        stream.Write(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
    }

    public T? Load()
    {
        if (File.Exists(_filePath))
        {
            using var stream = new StreamReader(File.Open(_filePath, FileMode.Open));
            var data = JsonSerializer.Deserialize<T>(stream.ReadToEnd(), new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return data;
        }

        return default;
    }
}