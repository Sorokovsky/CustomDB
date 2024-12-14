namespace Database.Contracts;

public interface IKeyGenerator<T>
{
    public T Current { get; }

    public void SetInitial(T initial);
}