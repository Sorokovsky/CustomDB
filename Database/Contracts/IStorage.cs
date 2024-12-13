namespace Database.Contracts;

public interface IStorage<T> where T : class
{
    public void Save(T data);

    public T? Load();
}