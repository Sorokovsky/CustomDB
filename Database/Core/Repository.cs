namespace Database.Core;

public class Repository<T> where T : class
{
    private LinkedList<T> _list = [];

    public T Add(T item)
    {
        var result = _list.AddLast(item).Value;
        return result;
    }
}