using Application.Database;
using Application.Database.Entities;

namespace Application;

public static class Program
{
    public static void Main()
    {
        var database = new DbContext();
        database.Entities.Add(new BaseEntity());
        database.Entities.Add(new BaseEntity());
        database.Entities.Add(new BaseEntity());
        database.Entities.Add(new BaseEntity());
    }
}