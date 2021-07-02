using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : PlayerBase
{
    protected override void OnEndEnemyTurn(PlayerBase enemy)
    {
        MakeChoice(enemy);
    }

    private void MakeChoice(PlayerBase enemy)
    {
        var allCheckedCells = new List<int>();
        allCheckedCells.AddRange(this.CheckedCells);
        allCheckedCells.AddRange(enemy.CheckedCells);

        if (controller.OutOfEmptyCells(allCheckedCells))
            return;

        List<int> emptyCells = CellsHelper.GetAvailableCells(allCheckedCells);
        int index = CellsHelper.GetRandomValue(emptyCells);
        Tile tile = Tile.GetTileById(index);
        tile.SetCharacter(character);
        controller.ApplyMove(tile, this);


        OnEndTurn.Invoke(this);
    }
}
