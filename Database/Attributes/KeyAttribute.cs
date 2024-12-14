using System.Reflection;
using Database.Constrains.Key;
using Database.Constrains.Key.Generation;
using Database.Contracts;
using Database.Core;
using Database.Services;

namespace Database.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class KeyAttribute : Attribute
{
    private IKeyGenerator<int> _generator;
    private IStorage<int> _storage;

    ~KeyAttribute()
    {
        DbEvents.PreCreated -= OnCreated;
    }

    public override void Construct(Type? parent, MemberInfo? memberInfo)
    {
        base.Construct(parent, memberInfo);
        _storage = new FileService<int>(Paths.GetLastKeyPath($"{Parent?.Name}.{Member?.Name}"));
        _generator = new Incremental(_storage.Load());
        DbEvents.PreCreated += OnCreated;
    }

    public override void Process()
    {
        var property = ConvertMemberToProperty();
        var key = Key.CreatePrimaryKey(Parent?.Name!, property?.Name!);
        var manager = KeysManager.Instance;
        manager.Add(key);
    }

    private void OnCreated(object data)
    {
        var property = ConvertMemberToProperty();
        var lastKey = _generator.Current;
        property.SetValue(data, lastKey);
        _storage.Save(lastKey);
    }

    private PropertyInfo ConvertMemberToProperty()
    {
        return (PropertyInfo)Member!;
    }
}