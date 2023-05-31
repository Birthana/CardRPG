using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<GameObject> charactersInEditor = new List<GameObject>();
    private Queue<GameObject> characters = new Queue<GameObject>();
    [SerializeField] private GameObject currentTurnCharacter;

    public bool IsPlayerTurn() { return currentTurnCharacter.GetComponent<Character>() != null; }

    private void Start()
    {
        AddCharactersInEditorToQueue();
        EndTurn();
    }

    private void AddCharactersInEditorToQueue()
    {
        foreach (var character in charactersInEditor)
        {
            characters.Enqueue(character);
        }
    }

    public GameObject GetCurrentTurnCharacter() { return currentTurnCharacter; }

    public void AddToTurnOrder(GameObject newCharacter) { characters.Enqueue(newCharacter); }

    public void Reorder()
    {

    }

    public void EndTurn()
    {
        if(currentTurnCharacter != null)
        {
            characters.Enqueue(currentTurnCharacter);
        }
        currentTurnCharacter = characters.Dequeue();
    }


}
