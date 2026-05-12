using BinPackingElevator;
using BinPackingElevator.Helpers;

var (n, x, weights) = DataGenerator.GenerateData();

ElevatorProblem elevatorProblem = new ElevatorProblem(n, x, weights);
elevatorProblem.Solve();
elevatorProblem.PrintResult();