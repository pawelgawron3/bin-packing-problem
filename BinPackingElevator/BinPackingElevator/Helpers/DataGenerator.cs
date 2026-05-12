namespace BinPackingElevator.Helpers;

public static class DataGenerator
{
    public static (int n, int x, int[] weights) GenerateData(int? seed = null)
    {
        Random random = seed.HasValue ? new Random(seed.Value) : new Random();

        int n = random.Next(1, 31);
        int capacity = random.Next(1, 1_000_001);
        int[] weights = new int[n];

        for (int i = 0; i < n; i++)
        {
            weights[i] = random.Next(1, capacity + 1);
        }

        return (n, capacity, weights);
    }
}