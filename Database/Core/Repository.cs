using Database.Contracts;
using Database.Services;

namespace Database.Core;

public class Repository<T>
{
    public delegate bool IsNeed(T item);

    private readonly IStorage<LinkedList<T>> _storage;
    private LinkedList<T> _list = [];

    public Repository(string tableName)
    {
        _storage = new FileService<LinkedList<T>>(Paths.GetTablePath(tableName));
        Load();
    }

    public IReadOnlyList<T> List => _list.ToList();

    public T Add(T item)
    {
        DbEvents.OnPreCreated(item);
        var result = _list.AddLast(item).Value;
        DbEvents.OnPostCreated(result);
        Save();
        return result;
    }

    public IReadOnlyList<T> Find(IsNeed predicate)
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
                DbEvents.OnPostRemoved(x);
            });
            Save();
        }
    }

    public void Update(IsNeed predicate, T updated)
    {
        var candidates = Find(predicate);
        if (candidates.Count == 0)
        {
            DbEvents.OnNotUpdated($"{typeof(T).Name} not found to update.");
        }
        else
        {
            candidates.ToList().ForEach(x =>
            {
                DbEvents.OnPreUpdated(x, updated);
                _list.Find(x)!.Value = updated;
                DbEvents.OnPostUpdated(updated);
            });
            Save();
        }
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