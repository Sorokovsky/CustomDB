using Database.Core;

namespace Application;

public static class Program
{
    public static void Main()
    {
        var repo = new Repository<int>("numbers");
        repo.Remove(x => x == 5);
        var list = repo.List;
        list.ToList().ForEach(Console.WriteLine);
    }
}