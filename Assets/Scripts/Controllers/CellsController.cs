using System;
using System.Collections.Generic;
using UnityEngine;

public class CellsController : MonoBehaviour
{
    [SerializeField] private T3Controller mainController;

    public const int GridSize = 3;
    public const int MaxAmount = 9;
    public List<int> Cells { get; private set; }


    private List<int> _rowsContainer;
    private List<int> _colsContainer;
    private List<int> _diagonalContainer;
    private List<int> _oppositeDiagonalContainer;

    public bool OutOfEmptyCells(List<int> cells)
    {
        return cells.Count >= MaxAmount;
    }

    public void ApplyMove(Tile tile, PlayerBase player)
    {
        AppendCheckedCells(tile);
        _rowsContainer[tile.Row] += 1;
        _colsContainer[tile.Column] += 1;

        if (tile.Row == tile.Column)
            _diagonalContainer[tile.Row] += 1;

        if (tile.Row + tile.Column + 1 == GridSize)
            _oppositeDiagonalContainer[tile.Row] += 1;

        if (IsWinnable(_rowsContainer[tile.Row]))
            mainController.RaiseWin(player);

        if (IsWinnable(_colsContainer[tile.Column]))
            mainController.RaiseWin(player);

        var sumForRegularDiagonalElements = 0;
        var sumForOppositeDiagonalElements = 0;

        for(int index = 0; index < _diagonalContainer.Count; index++)
        {
            sumForRegularDiagonalElements += _diagonalContainer[index];
            sumForOppositeDiagonalElements += _oppositeDiagonalContainer[index];
        }

        if (IsWinnable(sumForRegularDiagonalElements))
            mainController.RaiseWin(player);

        if (IsWinnable(sumForOppositeDiagonalElements))
            mainController.RaiseWin(player);
    }

    private void Start()
    {
        Cells = new List<int>();
        _rowsContainer = new List<int>(new int[] { 0, 0, 0 });
        _colsContainer = new List<int>(new int[] { 0, 0, 0 });
        _diagonalContainer = new List<int>(new int[] { 0, 0, 0 });
        _oppositeDiagonalContainer = new List<int>(new int[] { 0, 0, 0 });
}

    private void AppendCheckedCells(Tile checkedTile)
    {
        Cells.Add(checkedTile.id);
    }

    private bool IsWinnable(int value)
    {
        return value == GridSize;
    }
}
