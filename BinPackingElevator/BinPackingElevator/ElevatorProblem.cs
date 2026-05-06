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

        FindMinimalElevators(0, 0);
        return _minElevators;
    }

    private void FindMinimalElevators(int personIndex, int currentElevatorsCount)
    {
        if (currentElevatorsCount >= _minElevators) return;

        if (personIndex == _n)
        {
            _minElevators = currentElevatorsCount;
            return;
        }

        long remainingWeight = _weightSums[personIndex];
        if (currentElevatorsCount + Math.Ceiling((double)remainingWeight / _capacity) > _minElevators)
            return;

        int lastCapacityTried = -1;

        for (int i = 0; i < currentElevatorsCount; i++)
        {
            if (_elevators[i] + _weights[personIndex] <= _capacity)
            {
                if (_elevators[i] == lastCapacityTried) continue;

                _elevators[i] += _weights[personIndex];
                FindMinimalElevators(personIndex + 1, currentElevatorsCount);
                _elevators[i] -= _weights[personIndex];

                lastCapacityTried = _elevators[i];

                if (_elevators[i] + _weights[personIndex] == _capacity) return;
            }
        }

        if (currentElevatorsCount + 1 < _minElevators)
        {
            _elevators[currentElevatorsCount] = _weights[personIndex];
            FindMinimalElevators(personIndex + 1, currentElevatorsCount + 1);
            _elevators[currentElevatorsCount] = 0;
        }
    }
}