namespace Database.Contracts;

public static class Paths
{
    private const string BasePath = "database";

    public static string GetTablePath(string fileName)
    {
        var folder = $"{BasePath}\\tables";
        CreateFolderIfNotExists(folder);
        return $"{folder}\\{fileName}.dat";
    }

    public static string GetLastKeyPath(string fileName)
    {
        var folder = $"{BasePath}\\lastKey";
        CreateFolderIfNotExists(folder);
        return $"{folder}\\{fileName}.dat";
    }

    public static string GetPrimaryKeyPath(string fileName)
    {
        var folder = $"{BasePath}\\keys\\primary";
        return $"{folder}\\{fileName}.dat";
    }

    public static string GetForeignPath(string fileName)
    {
        var folder = $"{BasePath}\\keys\\foreign";
        return $"{folder}\\{fileName}.dat";
    }

    private static void CreateFolderIfNotExists(string folder)
    {
        var folders = folder.Split("\\");
        var result = string.Empty;
        foreach (var directory in folders)
        {
            result += directory + "\\";
            if (Directory.Exists(result) == false) Directory.CreateDirectory(result);
        }
    }
}