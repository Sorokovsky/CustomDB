namespace Database.Core;

public class Repository<T> where T : class
{
    private LinkedList<T> _list = [];

    public T Add(T item)
    {
        DbContext.Events.OnPreCreated(item);
        var result = _list.AddLast(item).Value;
        DbContext.Events.OnCreated(result);
        return result;
    }
}