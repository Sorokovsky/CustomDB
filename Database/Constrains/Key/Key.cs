namespace Database.Constrains.Key;

public class Key
{
    public Key(KeyType type, string parentName, string memberName)
    {
        Type = type;
        ParentName = parentName;
        MemberName = memberName;
    }

    public KeyType Type { get; }

    public string ParentName { get; }

    public string MemberName { get; }

    public override bool Equals(object? obj)
    {
        if (obj is Key otherKey)
            return Type == otherKey.Type && ParentName == otherKey.ParentName && MemberName == otherKey.MemberName;

        return false;
    }

    protected bool Equals(Key other)
    {
        return Equals((object)other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Type, ParentName, MemberName);
    }

    public static bool operator ==(Key first, Key second)
    {
        return first.Equals(second);
    }

    public static bool operator !=(Key first, Key second)
    {
        return !(first == second);
    }

    public static Key CreatePrimaryKey(string parentName, string memberName)
    {
        return new Key(KeyType.Primary, parentName, memberName);
    }

    public static Key CreateForeignKey(string parentName, string memberName)
    {
        return new Key(KeyType.Foreign, parentName, memberName);
    }
}