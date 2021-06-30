using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : PlayerBase
{
    protected override void OnEndEnemyTurn(PlayerBase enemy)
    {
        MakeChoice();
    }
    /// <summary>
    /// Выбор рандомной ячейки.
    /// </summary>
    private void MakeChoice()
    {
        CheckedCells checkedCells = controller.CheckedCells;
        List<int> emptyCells = Cells.GetAvailableCells(checkedCells);
        int index = Cells.GetRandomValue(emptyCells);
        Tile tile = Tile.GetTileById(index);
        tile.SetCharacter(character);
        controller.AppendCheckedCells(tile);
        OnEndTurn.Invoke(this);
    }
}
