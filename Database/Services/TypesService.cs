namespace Database.Services;

public static class TypesService
{
    public static IEnumerable<Type> GetAllTypes()
    {
        var types = new List<Type>();
        AppDomain.CurrentDomain.GetAssemblies().ToList()
            .ForEach(x => types.AddRange(x.GetTypes()));
        return types;
    }
}