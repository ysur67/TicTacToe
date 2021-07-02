using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3Player : PlayerBase
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ApplyMouseClick();
    }

    private void ApplyMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            GameObject hitObject = hit.transform.gameObject;
            Tile tile = hitObject.GetComponent<Tile>();
            if (tile)
                ApplyTileClick(tile);
        }
    }

    private void ApplyTileClick(Tile tile)
    {
        if (!tile.TrySetCharacter())
            return;

        tile.SetCharacter(character);
        controller.ApplyMove(tile, this);

        OnEndTurn.Invoke(this);
    }
    protected override void OnEndEnemyTurn(PlayerBase enemy)
    {
        Debug.Log("OVERRIDE");
    }
}
