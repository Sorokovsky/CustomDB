using System.Reflection;
using Database.Services;

namespace Database.Attributes;

public class AttributeManager
{
    private readonly List<Type> _types = TypesService.GetAllTypes().ToList();

    private List<MemberInfo> CollectProviders()
    {
        var all = new List<MemberInfo>();
        var providers = new List<MemberInfo>();
        _types.ForEach(x =>
        {
            all.Add(x);
            all.AddRange(x.GetMembers());
        });
        all.ForEach(x =>
        {
            if (x is ICustomAttributeProvider) providers.Add(x);
        });
        return providers;
    }

    public void ExecuteAttributes()
    {
        var providers = CollectProviders();
        providers.ForEach(provider =>
        {
            var attributes = provider.GetCustomAttributes(true);
            foreach (var attribute in attributes)
                if (attribute is Attribute custom)
                {
                    custom.Construct(provider.DeclaringType, provider);
                    custom.Process();
                }
        });
    }
}