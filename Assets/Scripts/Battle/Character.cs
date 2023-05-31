using System;
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
public class Character : MonoBehaviour
{
    public Action<int> OnActionChange;
    [SerializeField] private CharacterStats stats;
    [SerializeField] private int maxActions;
    private int currentActions;

    private void Start()
    {
        OnActionChange += GetComponent<BasicUI>().Display;
        SetCurrentActions(maxActions);
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

    public void ResetActions() { currentActions = maxActions; }

    private void SetCurrentActions(int actionAmount)
    {
        currentActions = actionAmount;
        OnActionChange?.Invoke(currentActions);
    }
}
