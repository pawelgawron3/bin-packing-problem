using BinPackingElevator.Helpers;

namespace BinPackingElevator;

public class ElevatorProblem
{
    private readonly int _n;
    private readonly int _capacity;
    private readonly int[] _weights;
    private int[] _elevators;
    private int _minElevators;
    private long[] _weightSums;

    private List<List<int>> _currentAssignment = new();
    private List<List<int>> _bestAssignment = new();

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
        for (int i = 0; i < _n; i++) _currentAssignment.Add([]);

        _weightSums = new long[_n + 1];
        for (int i = _n - 1; i >= 0; i--)
            _weightSums[i] = _weightSums[i + 1] + _weights[i];

        FindMinimalElevators(0, 0);
        return _minElevators;
    }

    public void PrintResult()
    {
        Console.WriteLine($"Summary for {_n} people | Capacity: {_capacity}kg");
        Console.WriteLine($"Optimal number of trips: {_minElevators}");
        Console.WriteLine(new string('-', 50));

        for (int i = 0; i < _bestAssignment.Count; i++)
        {
            string people = string.Join(", ", _bestAssignment[i]);
            int total = _bestAssignment[i].Sum();
            double usage = (double)total / _capacity * 100;

            Console.WriteLine($"Trip #{i + 1,-2} | Weights: [{people}] | Total: {total} ({usage:0.0}%)");
        }
    }

    private void FindMinimalElevators(int personIndex, int currentElevatorsCount)
    {
        if (currentElevatorsCount >= _minElevators) return;

        if (personIndex == _n)
        {
            _minElevators = currentElevatorsCount;
            AssignmentHelper.SaveBestAssignment(currentElevatorsCount, _currentAssignment, _bestAssignment);
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
                _currentAssignment[i].Add(_weights[personIndex]);
                FindMinimalElevators(personIndex + 1, currentElevatorsCount);
                _currentAssignment[i].RemoveAt(_currentAssignment[i].Count - 1);
                _elevators[i] -= _weights[personIndex];

                lastCapacityTried = _elevators[i];

                if (_elevators[i] + _weights[personIndex] == _capacity) return;
            }
        }

        if (currentElevatorsCount + 1 < _minElevators)
        {
            _elevators[currentElevatorsCount] = _weights[personIndex];
            _currentAssignment[currentElevatorsCount].Add(_weights[personIndex]);
            FindMinimalElevators(personIndex + 1, currentElevatorsCount + 1);
            _currentAssignment[currentElevatorsCount].RemoveAt(_currentAssignment[currentElevatorsCount].Count - 1);
            _elevators[currentElevatorsCount] = 0;
        }
    }
}