using System.Collections.Generic;

public class CheckedCells
{
    private List<int> _cells;
       
    public CheckedCells()
    {
        _cells = new List<int>();
    }
    public void AppendCheckedCells(int value)
    {
        _cells.Add(value);
    }

    public List<int> Cells => _cells;

}
