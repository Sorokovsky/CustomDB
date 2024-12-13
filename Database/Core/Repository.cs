namespace Database.Core;

public class Repository<T> where T : class
{
    private readonly LinkedList<T> _list = [];

    public T Add(T item)
    {
        DbEvents.OnPreCreated(item);
        var result = _list.AddLast(item).Value;
        DbEvents.OnCreated(result);
        return result;
    }
}