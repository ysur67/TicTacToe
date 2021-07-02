using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerBase : MonoBehaviour
{
    [SerializeField] protected Character character;
    [SerializeField] protected PlayerBase enemy;
    [SerializeField] protected CellsController controller;

    public Action<PlayerBase> OnEndTurn;
    public List<int> CheckedCells => controller.Cells;
    public string username;

    protected int cellsSum = 0;

    private void OnEnable()
    {
        enemy.OnEndTurn += OnEndEnemyTurn;
        if (username.Length < 1)
            username = "user";
    }

    private void OnDisable()
    {
        enemy.OnEndTurn -= OnEndEnemyTurn;
    }

    protected abstract void OnEndEnemyTurn(PlayerBase enemy);
}
