using System;
using System.Collections.Generic;
using UnityEngine;



public abstract class PlayerBase : MonoBehaviour
{
    [SerializeField] protected Character character;
    [SerializeField] protected PlayerBase enemy;
    [SerializeField] protected T3Controller controller;

    public Action<PlayerBase> OnEndTurn;

    private void OnEnable()
    {
        enemy.OnEndTurn += OnEndEnemyTurn;
    }

    private void OnDisable()
    {
        enemy.OnEndTurn -= OnEndEnemyTurn;
    }

    protected abstract void OnEndEnemyTurn(PlayerBase enemy);
}
