namespace Database.Core;

public class DbEvents
{
    public delegate void Operation(object data);

    public static event Operation PreCreated;

    public static event Operation Created;

    public static void OnPreCreated(object data)
    {
        PreCreated?.Invoke(data);
    }

    public static void OnCreated(object data)
    {
        Created?.Invoke(data);
    }
}