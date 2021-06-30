using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3Player : PlayerBase
{
    private string username;
    public void SetUsername(string value) { username = value; }
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
            int id = tile.id;

            if (tile.TrySetCharacter())
            {
                tile.SetCharacter(this.character);
                controller.AppendCheckedCells(tile);
                OnEndTurn.Invoke(this);
            }
        }
    }
    protected override void OnEndEnemyTurn(PlayerBase enemy)
    {
        Debug.Log("OVERRIDE");
    }
}
