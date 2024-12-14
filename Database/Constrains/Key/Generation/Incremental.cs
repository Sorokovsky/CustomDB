using Database.Contracts;

namespace Database.Constrains.Key.Generation;

public class Incremental : IKeyGenerator<int>
{
    private int _initial;

    public Incremental(int initial = 0)
    {
        _initial = initial;
    }

    public int Current => ++_initial;

    public void SetInitial(int initial)
    {
        _initial = initial;
    }
}