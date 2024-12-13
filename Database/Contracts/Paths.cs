namespace Database.Contracts;

public static class Paths
{
    private const string BasePath = "database";

    public static string GetTablePath(string fileName)
    {
        return $"{BasePath}/tables/{fileName}.dat";
    }

    public static string GetLastKeyPath(string fileName)
    {
        return $"{BasePath}/lastKey/{fileName}.dat";
    }

    public static string GetPrimaryKeyPath(string fileName)
    {
        return $"{BasePath}/keys/primary/{fileName}.dat";
    }

    public static string GetForeignPath(string fileName)
    {
        return $"{BasePath}/keys/foreign/{fileName}.dat";
    }
}