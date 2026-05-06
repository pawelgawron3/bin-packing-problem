namespace BinPackingElevator;

public class ElevatorProblem
{
    private int _n;
    private int _capacity;
    private int[] _weights;
    private int[] _elevators;
    private int _minElevators;
    private long[] _weightSums;

    public ElevatorProblem(int n, int capacity, int[] weights)
    {
        this._n = n;
        this._capacity = capacity;
        this._weights = weights.OrderByDescending(x => x).ToArray();
    }

    public int Solve()
    {
        _elevators = new int[_n];
        _minElevators = _n;

        _weightSums = new long[_n + 1];
        for (int i = _n - 1; i >= 0; i--)
            _weightSums[i] = _weightSums[i + 1] + _weights[i];
    }
}