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
    private Action OnStartOfTurn;
    [SerializeField] private CharacterStats stats;
    private Coroutine currentAction;
    private Energy energy;
    private Hover hover;
    private CardDragger cardDragger;

    private void Awake()
    {
        SetStartOfTurnCallbacks();
        cardDragger = new CardDragger(GetComponent<Hand>(), energy);
    }

    private void SetStartOfTurnCallbacks()
    {
        SetHoverCallbacks();
        SetEnergyCallbacks();
        SetWeaponCallbacks();
        SetDeckCallbacks();
    }

    private void SetHoverCallbacks()
    {
        hover = new Hover();
        OnStartOfTurn += hover.ResetHoveredCard;
    }

    private void SetEnergyCallbacks()
    {
        energy = GetComponentInChildren<Energy>();
        OnStartOfTurn += energy.ResetActions;
    }

    private void SetWeaponCallbacks() { OnStartOfTurn += FindObjectOfType<Weapon>().UnTap; }

    private void SetDeckCallbacks() { OnStartOfTurn += GetComponent<Deck>().DrawToHand; }

    public void SetStartOfTurnEffect(Action effect) { OnStartOfTurn += effect; }

    public void RemoveStartOfTurnEffect(Action effect) { OnStartOfTurn -= effect; }

    public Energy GetEnergy() { return energy; }

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
                yield return StartCoroutine(CastCard());
            }

            if(Mouse.IsOnHandLayer())
            {
                hover.RaiseCard();
            }

            yield return null;
        }
    }

    private IEnumerator CastCard()
    {
        cardDragger.PickUpCard();
        if (cardDragger.CharacterCanCastCard())
        {
            var selectedCard = cardDragger.Get();
            yield return StartCoroutine(selectedCard.Targeting(cardDragger.CastSelectedCard));
        }
    }
}
