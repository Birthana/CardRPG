using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card cardPrefab;
    private List<Card> cards = new List<Card>();
    private float CARD_SPACING = 10.0f;

    public void Add(CardInfo cardToSpawn)
    {
        Card newCard = Instantiate(cardPrefab, transform);
        newCard.SetCardInfo(cardToSpawn);
        cards.Add(newCard);
        DisplayHand();
    }

    public void Remove(Card card)
    {
        cards.Remove(card);
        Destroy(card.gameObject);
        DisplayHand();
    }

    void DisplayHand()
    {
        var positions = new CenterPosition(cards.Count, CARD_SPACING);
        for (int cardIndex = 0; cardIndex < cards.Count; ++cardIndex)
        {
            MoveCardAt(cardIndex, positions.CalcPositionAt(cardIndex));
        }
    }

    void MoveCardAt(int cardIndex, Vector3 position)
    {
        cards[cardIndex].transform.localPosition = position;
    }
}
