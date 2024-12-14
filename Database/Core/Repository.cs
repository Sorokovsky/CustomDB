using Database.Contracts;
using Database.Services;

namespace Database.Core;

public class Repository<T> where T : class
{
    private readonly IStorage<LinkedList<T>> _storage;
    private LinkedList<T> _list = [];

    public delegate bool IsNeed(T item);

    public IReadOnlyList<T> List => _list.ToList();

    public Repository(string tableName)
    {
        _storage = new FileService<LinkedList<T>>(Paths.GetTablePath(tableName));
        Load();
    }

    public T Add(T item)
    {
        DbEvents.OnPreCreated(item);
        var result = _list.AddLast(item).Value;
        DbEvents.OnCreated(result);
        Save();
        return result;
    }

    private IReadOnlyList<T> Find(IsNeed predicate)
    {
        return List.Where(predicate.Invoke).ToList();
    }

    public void Remove(IsNeed predicate)
    {
        var candidates = Find(predicate);
        if (candidates.Count == 0)
        {
            DbEvents.OnNotRemoved($"{typeof(T).Name} for deleting not found.");
        }
        else
        {
            candidates.ToList().ForEach(x =>
            {
                DbEvents.OnPreRemoved(x);
                _list.Remove(x);
                DbEvents.OnRemoved(x);
            });
        }
        Save();
    }

    private void Save()
    {
        _storage.Save(_list);
    }

    private void Load()
    {
        _list = _storage.Load() ?? [];
    }
}