using Database.Attributes;

namespace Database.Core;

public abstract class DbContext
{
    private readonly AttributeManager _attributeManager = new();

    protected DbContext()
    {
        _attributeManager.ExecuteAttributes();
    }
}