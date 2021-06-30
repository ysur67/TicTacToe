using System.Collections.Generic;

public class WinnableCollections
{
    private Dictionary<int, int[]> _winnableCollections;

    public WinnableCollections()
    {
        _winnableCollections = new Dictionary<int, int[]>();
        _winnableCollections.Add(1, new int[] { 1, 2, 3 });
        _winnableCollections.Add(2, new int[] { 4, 5, 6 });
        _winnableCollections.Add(3, new int[] { 7, 8, 9 });
        _winnableCollections.Add(4, new int[] { 1, 5, 9 });
        _winnableCollections.Add(5, new int[] { 3, 5, 7 });
        _winnableCollections.Add(6, new int[] { 1, 4, 7 });
        _winnableCollections.Add(7, new int[] { 2, 5, 8 });
        _winnableCollections.Add(8, new int[] { 3, 6, 9 });
    }

    public bool IsWinnable(int[] values)
    {
        return _winnableCollections.ContainsValue(values);
    }
}
