using System;
using UnityEngine;

[RequireComponent(typeof(BasicUI))]
public class Energy : MonoBehaviour
{
    public Action<int> OnActionChange;
    [SerializeField] private int maxActions;
    private int currentActions;

    private void Awake()
    {
        SetActionChangeCallbacks();
    }

    private void Start()
    {
        SetCurrentActions(maxActions);
    }

    private void SetActionChangeCallbacks()
    {
        OnActionChange += GetComponent<BasicUI>().Display;
    }

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
}
