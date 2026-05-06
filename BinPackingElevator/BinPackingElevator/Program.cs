using BinPackingElevator;

// Example
int n = 12;
int x = 90;
int[] weights =
[
    34, 66, 32, 55, 54,
    46, 80, 82, 20, 71,
    5, 5
];

ElevatorProblem elevatorProblem = new ElevatorProblem(n, x, weights);
elevatorProblem.Solve();
elevatorProblem.PrintResult();