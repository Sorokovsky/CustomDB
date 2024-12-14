using Database.Contracts;
using Database.Services;

namespace Database.Constrains.Key;

public class KeysManager
{
    private readonly LinkedList<Key> _list;
    private readonly IStorage<LinkedList<Key>> _storage;

    public KeysManager()
    {
        _storage = new FileService<LinkedList<Key>>(Paths.GetKeyPath());
        _list = _storage.Load() ?? [];
    }

    public IReadOnlyList<Key> List => _list.ToList();

    public void Add(Key item)
    {
        _list.AddLast(item);
        _storage.Save(_list);
    }

    public void Remove(Key item)
    {
        _list.Remove(item);
        _storage.Save(_list);
    }
}