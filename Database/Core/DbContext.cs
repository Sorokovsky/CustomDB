using Database.Attributes;

namespace Database.Core;

public abstract class DbContext
{
    private readonly AttributeManager _attributeManager;

    public DbContext()
    {
        _attributeManager = new AttributeManager();
        _attributeManager.ExecuteAttributes();
    }
}