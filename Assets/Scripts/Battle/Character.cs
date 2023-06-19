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

[RequireComponent(typeof(BasicUI))]
[RequireComponent(typeof(Deck))]
public class Character : TakeTurn
{
    public Action<int> OnActionChange;
    public Action OnStartOfTurn;
    [SerializeField] private CharacterStats stats;
    [SerializeField] private int maxActions;
    private int currentActions;
    private Coroutine currentAction;

    private void Awake()
    {
        SetActionChangeCallbacks();
        SetStartOfTurnCallbacks();
    }

    private void Start()
    {
        SetCurrentActions(maxActions);
    }

    private void SetActionChangeCallbacks()
    {
        OnActionChange += GetComponent<BasicUI>().Display;
    }

    private void SetStartOfTurnCallbacks()
    {
        OnStartOfTurn += ResetActions;
        OnStartOfTurn += GetComponent<Deck>().DrawToHand;
        var weapon = FindObjectOfType<Weapon>();
        OnStartOfTurn += weapon.UnTap;
    }

    public int GetTime() { return stats.time; }

    public bool HasActions(int actions) { return currentActions >= actions; }

    public void UseActions(int actionAmount) 
    {
        var actions = Mathf.Max(0, currentActions - actionAmount);
        SetCurrentActions(actions);
    }

    public void AddActions(int actionAmount)
    {
        maxActions += actionAmount;
        AddTempActions(actionAmount);
    }

    public void AddTempActions(int actionAmount)
    {
        var actions = currentActions + actionAmount;
        SetCurrentActions(actions);
    }

    public void ResetActions() { SetCurrentActions(maxActions); }

    private void SetCurrentActions(int actionAmount)
    {
        currentActions = actionAmount;
        OnActionChange?.Invoke(currentActions);
    }

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

    public IEnumerator CanDoActions()
    {
        var turnManager = FindObjectOfType<TurnManager>();
        var cardDragger = GetComponentInChildren<CardDragger>();
        while (turnManager.IsPlayerTurn())
        {
            if (Mouse.PlayerPressesLeftClick() && Mouse.IsOnHandLayer())
            {
                yield return StartCoroutine(cardDragger.PickUpCard());
            }

            yield return null;
        }
    }
}
