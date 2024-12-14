using System.Reflection;

namespace Database.Attributes;

public abstract class Attribute : System.Attribute
{
    public Type? Parent { get; private set; }

    public MemberInfo? Member { get; private set; }

    public virtual void Construct(Type? parent, MemberInfo? memberInfo)
    {
        Parent = parent;
        Member = memberInfo;
    }

    public abstract void Process();
}