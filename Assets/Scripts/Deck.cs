using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpawnCard
{
    [SerializeReference] public CardInfo card;
    public int quantity;
}

public class Deck : MonoBehaviour
{
    public List<SpawnCard> cardsInDeck = new List<SpawnCard>();
    private Queue<CardInfo> deck = new Queue<CardInfo>();
    private Hand hand;

    private void Start()
    {
        hand = FindObjectOfType<Hand>();
        FillDeckWithCards();
        Shuffle();
        for (int i = 0; i < 5; i++)
        {
            Draw();
        }
    }

    public void FillDeckWithCards()
    {
        foreach (var card in cardsInDeck)
        {
            for (int i = 0; i < card.quantity; i++)
            {
                deck.Enqueue(card.card);
            }
        }
    }

    public CardInfo Draw()
    {
        var card = deck.Dequeue();
        hand.Add(card);
        return card;
    }

    public void Shuffle()
    {
        var tempDeck = deck.ToArray();
        for (int i = 0; i < tempDeck.Length; i++)
        {
            var temp = tempDeck[i];
            int randomIndex = UnityEngine.Random.Range(i, deck.Count);
            tempDeck[i] = tempDeck[randomIndex];
            tempDeck[randomIndex] = temp;
        }

        deck = new Queue<CardInfo>(tempDeck);
    }
}
