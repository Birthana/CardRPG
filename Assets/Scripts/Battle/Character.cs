using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct CharacterStats
{
    public int health;
    public int speed;
    public int time;
    public int deckCapacity;
}

[RequireComponent(typeof(Deck))]
public class Character : TakeTurn
{
    public Action OnStartOfTurn;
    [SerializeField] private CharacterStats stats;
    private Coroutine currentAction;
    private Energy energy;

    private void Awake()
    {
        energy = GetComponentInChildren<Energy>();
        SetStartOfTurnCallbacks();
    }

    private void SetStartOfTurnCallbacks()
    {
        var hover = GetComponentInChildren<Hover>();
        OnStartOfTurn += hover.ResetHoveredCard;
        OnStartOfTurn += energy.ResetActions;
        OnStartOfTurn += GetComponent<Deck>().DrawToHand;
        var weapon = FindObjectOfType<Weapon>();
        OnStartOfTurn += weapon.UnTap;
    }

    public Energy GetEnergy()
    {
        return energy;
    }

    public int GetTime() { return stats.time; }

    public override void PerformStartOfTurnActions()
    {
        Debug.Log($"Your Turn.");
        OnStartOfTurn?.Invoke();
        if (currentAction != null)
        {
            StopCoroutine(currentAction);
        }

        currentAction = StartCoroutine(CanDoActions());
    }

    private bool CharacterIsTakingTurn() 
    {
        var turnManager = FindObjectOfType<TurnManager>();
        return turnManager.IsPlayerTurn(); 
    }

    private bool CharacterIsCastingHandCard() { return Mouse.PlayerPressesLeftClick() && Mouse.IsOnHandLayer(); }

    private IEnumerator CanDoActions()
    {
        while (CharacterIsTakingTurn())
        {
            if (CharacterIsCastingHandCard())
            {
                var cardDragger = GetComponentInChildren<CardDragger>();
                yield return StartCoroutine(cardDragger.PickUpCard());
            }

            if(Mouse.IsOnHandLayer())
            {
                var hover = GetComponentInChildren<Hover>();
                hover.RaiseCard();
            }

            yield return null;
        }
    }
}
