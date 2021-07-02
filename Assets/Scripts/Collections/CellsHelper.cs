using System.Collections.Generic;
using System.Linq;

public static class CellsHelper
{
    public static List<int> GetAvailableCells(List<int> checkedCollections)
    {
        List<int> allCells = GetCellsCollection();
        var availableCells = allCells.Except(checkedCollections);
        return Distinct(availableCells);
    }

    public static List<int> Distinct(IEnumerable<int> values)
    {
        return values.Distinct().ToList();
    }

    public static List<int> GetCellsCollection()
    {
        var resultCollection = new List<int>();
        var maxCells = 9;
        for (int i = 0; i < maxCells; i++)
            resultCollection.Add(i);
        return resultCollection;
    }

    public static int GetRandomValue(List<int> values)
    {
        var random = new System.Random();
        var index = random.Next(values.Count);
        return values[index];
    }
}
