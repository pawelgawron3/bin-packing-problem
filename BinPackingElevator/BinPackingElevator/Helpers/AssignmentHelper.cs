namespace BinPackingElevator.Helpers;

public static class AssignmentHelper
{
    public static void SaveBestAssignment(int count, List<List<int>> source, List<List<int>> destination)
    {
        destination.Clear();
        for (int i = 0; i < count; i++)
        {
            destination.Add([.. source[i]]);
        }
    }
}