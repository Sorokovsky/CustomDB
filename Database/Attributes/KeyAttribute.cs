using System.Reflection;
using Database.Constrains.Key;

namespace Database.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class KeyAttribute : Attribute
{
    public override void Process()
    {
        var property = ConvertMemberToProperty();
        var key = Key.CreatePrimaryKey(Parent?.Name!, property?.Name!);
        var manager = KeysManager.Instance;
        manager.Add(key);
    }

    public PropertyInfo ConvertMemberToProperty()
    {
        return (PropertyInfo)Member!;
    }
}