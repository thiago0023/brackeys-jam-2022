using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyInteraction : InteractionByTrigger
{
    public static event EventHandler<OnEnemyInteractArgs> OnInteract;
    private int darknessAmount;
    void Start()
    {
        var enemyStorage = GetComponent<EnemyStorage>();
        darknessAmount = enemyStorage.darknessAmount;
    }

    public override string GetName()
    {
        return"Enemy Interaction";
    }

    public override void Interact()
    {
        Debug.Log(GetName());
        var enemy = GetComponent<EnemyActions>();
        OnInteract?.Invoke(this, new OnEnemyInteractArgs { 
            enemy = enemy, 
            darknessAmount = darknessAmount 
        });
    }

    public override void BeginInteraction()
    {
        // throw new NotImplementedException();
    }

    public override void EndInteraction()
    {
        // throw new NotImplementedException();
    }
}

public class OnEnemyInteractArgs : EventArgs
{
    public EnemyActions enemy;
    public int darknessAmount;
}
