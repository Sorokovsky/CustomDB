namespace Database.Contracts;

public static class Paths
{
    private const string BasePath = "database";
    
    public static string GetTablePath(string fileName) => $"{BasePath}/tables/{fileName}.dat";

    public static string GetLastKeyPath(string fileName) => $"{BasePath}/lastKey/{fileName}.dat";

    public static string GetPrimaryKeyPath(string fileName) => $"{BasePath}/keys/primary/{fileName}.dat";

    public static string GetForeignPath(string fileName) => $"{BasePath}/keys/foreign/{fileName}.dat";
}