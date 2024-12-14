using Database.Contracts;
using Database.Services;

namespace Database.Constrains.Key;

public class KeysManager
{
    private readonly IStorage<LinkedList<Key>> _storage;

    private readonly LinkedList<Key> _list;

    public KeysManager()
    {
        _storage = new FileService<LinkedList<Key>>(Paths.GetKeyPath());
        _list = _storage.Load() ?? [];
    }

    public void Add(Key key)
    {
        var candidates = _list.Where(x => x == key).ToList();
    }
}