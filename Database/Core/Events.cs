namespace Database.Core;

public class Events
{
    public delegate void Operation(object data);

    public event Operation PreCreated;

    public event Operation Created;

    public void OnPreCreated(object data)
    {
        PreCreated?.Invoke(data);
    }

    public void OnCreated(object data)
    {
        Created?.Invoke(data);
    }
}