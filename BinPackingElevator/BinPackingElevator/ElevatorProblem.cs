using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        this._weights = weights;
    }
}