using Database.Contracts;
using Database.Services;

namespace Database.Constrains.Key;

public class KeysManager
{
    private static KeysManager? _instance;

    private readonly LinkedList<Key> _list;
    private readonly IStorage<LinkedList<Key>> _storage;

    public KeysManager()
    {
        _storage = new FileService<LinkedList<Key>>(Paths.GetKeyPath());
        _list = _storage.Load() ?? [];
    }

    public static KeysManager Instance => Singleton();

    public IReadOnlyList<Key> List => _list.ToList();

    private static KeysManager Singleton()
    {
        if (_instance == null) _instance = new KeysManager();
        return _instance;
    }

    public void Add(Key item)
    {
        if (_list.Contains(item) == false)
        {
            _list.AddLast(item);
            _storage.Save(_list);
        }
    }

    public void Remove(Key item)
    {
        _list.Remove(item);
        _storage.Save(_list);
    }
}