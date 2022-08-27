using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStorage : MonoBehaviour
{
    public static event EventHandler<int> OnIncreaseWisp;
    public static event EventHandler OnDecreaseWisp;
    public static event EventHandler<OnAnyWispStandArgs> WispStand_OnIncreaseWispAmount;
    public static event EventHandler<OnAnyWispStandArgs> WispStand_OnDecreaseWispAmount;
    public static event EventHandler PlayerAction_OnKillPlayer;
    public static event EventHandler<OnEnemyInteractArgs> EnemyActions_OnKillEnemy;
    private int wispsAmount;

    void OnEnable()
    {
        WispStand.OnAnyWispInteracted += WispStand_OnStandInteracted;
        WispInteraction.OnInteracted += WispInteraction_OnInteracted;
        EnemyInteraction.OnInteract += EnemyInteraction_OnInteract;
    }
    void OnDisable()
    {
        WispStand.OnAnyWispInteracted -= WispStand_OnStandInteracted;
        WispInteraction.OnInteracted -= WispInteraction_OnInteracted;
        EnemyInteraction.OnInteract -= EnemyInteraction_OnInteract;
    }

    private void IncreaseWispAmount(int amount, int lightIntensity = 0)
    {
        wispsAmount += amount;
        OnIncreaseWisp?.Invoke(this, lightIntensity);
    }

    private bool TryDecreaseAmount(int amount)
    {
        if (!CanSpendWisps(amount)) return false;

        wispsAmount -= amount;
        OnDecreaseWisp?.Invoke(this, EventArgs.Empty);
        return true;
    }

    private void WispStand_OnStandInteracted(object sender, OnAnyWispStandArgs e)
    {
        if (e.hasWisp)
        {
            IncreaseWispAmount(1);
            e.hasWisp = false;
            WispStand_OnIncreaseWispAmount?.Invoke(this, e);
        }
        else
        {
            if (!TryDecreaseAmount(1)) return;
            e.hasWisp = true;
            WispStand_OnDecreaseWispAmount?.Invoke(this, e);
        }
    }
    private void DecreaseWispAmount(int amount)
    {
        wispsAmount -= amount;
        OnDecreaseWisp?.Invoke(this, EventArgs.Empty);
    }

    private bool CanSpendWisps(int amount)
    {
        if (wispsAmount >= amount)
        {
            return true;
        }
        return false;
    }

    private void WispInteraction_OnInteracted(object sender, int intensityToAdd)
    {
        IncreaseWispAmount(1, intensityToAdd);
    }

    private void EnemyInteraction_OnInteract(object sender, OnEnemyInteractArgs args)
    {

        if (wispsAmount > args.darknessAmount) {
            EnemyActions_OnKillEnemy?.Invoke(this, args);
        }
        else {
            PlayerAction_OnKillPlayer?.Invoke(this, EventArgs.Empty);
        }
    }
}
