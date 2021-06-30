using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CheckedCells
{
    private List<int> _cells;

    public CheckedCells()
    {
        _cells = new List<int>();
    }
    public List<int> Cells => _cells;

    public void Add(int value)
    {
        _cells.Add(value);
    }

    public void Add(List<int> values)
    {
        _cells.AddRange(values);
    }
}

public static class Cells
{
    public static List<int> GetAvailableCells(CheckedCells checkedCollections)
    {
        List<int> allCells = GetCellsCollection();
        var availableCells = allCells.Except(checkedCollections.Cells);

        var res = Distinct(availableCells);
        res.ForEach(r => Debug.Log(r));
        return res;
    }

    public static List<int> Distinct(IEnumerable<int> values)
    {
        return values.Distinct().ToList();
    }

    public static CheckedCells Fold(CheckedCells[] checkedCollections)
    {
        CheckedCells foldCollection = new CheckedCells();
        foreach (CheckedCells collection in checkedCollections)
        {
            foldCollection.Add(collection.Cells);
        }
        return foldCollection;
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
