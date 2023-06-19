using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<TakeTurn> characters = new List<TakeTurn>();
    [SerializeField] private TakeTurn currentTurnCharacter;

    public bool IsPlayerTurn() { return currentTurnCharacter.GetComponent<Character>() != null; }

    private void Start()
    {
        EndTurn();
    }

    public TakeTurn GetCurrentTurnCharacter() { return currentTurnCharacter; }

    public void AddToTurnOrder(TakeTurn newCharacter) { characters.Add(newCharacter); }

    public void RemoveFromTurnOrder(TakeTurn characterToRemove) { characters.Remove(characterToRemove); }

    public TakeTurn GetNextCharacter()
    {
        var nextCharacter = characters[0];
        characters.RemoveAt(0);
        return nextCharacter;
    }

    public void EndTurn()
    {
        if(currentTurnCharacter != null)
        {
            AddToTurnOrder(currentTurnCharacter);
        }

        currentTurnCharacter = GetNextCharacter();
        currentTurnCharacter.PerformStartOfTurnActions();
    }


}
