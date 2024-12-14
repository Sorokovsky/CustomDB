namespace Database.Contracts;

public interface IStorage<T>
{
    public void Save(T data);

    public T? Load();
}