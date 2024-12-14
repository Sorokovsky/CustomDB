namespace Database.Core;

public class DbEvents
{
    public delegate void ErrorHandler(string reason);

    public delegate void Operation(object data);

    public static event Operation PreCreated;

    public static event Operation PostCreated;

    public static event Operation PreRemoved;

    public static event Operation PostRemoved;

    public static event ErrorHandler NotRemoved;

    public static void OnPreCreated(object data)
    {
        PreCreated?.Invoke(data);
    }

    public static void OnPostCreated(object data)
    {
        PostCreated?.Invoke(data);
    }

    public static void OnPostRemoved(object data)
    {
        PostRemoved?.Invoke(data);
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