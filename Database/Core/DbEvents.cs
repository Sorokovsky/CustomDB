namespace Database.Core;

public class DbEvents
{
    public delegate void Operation(object data);

    public delegate void ErrorHandler(string reason);

    public static event Operation PreCreated;

    public static event Operation Created;

    public static event Operation PreRemoved;

    public static event Operation Removed;

    public static event ErrorHandler NotRemoved;

    public static void OnPreCreated(object data)
    {
        PreCreated?.Invoke(data);
    }

    public static void OnCreated(object data)
    {
        Created?.Invoke(data);
    }

    public static void OnRemoved(object data)
    {
        Removed?.Invoke(data);
    }

    public static void OnPreRemoved(object data)
    {
        PreRemoved?.Invoke(data);
    }

    public static void OnNotRemoved(string reason)
    {
        NotRemoved?.Invoke(reason);
    }
}