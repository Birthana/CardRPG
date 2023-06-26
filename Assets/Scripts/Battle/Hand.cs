using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card cardPrefab;
    private List<Card> cards = new List<Card>();
    private int CARD_SPACING = 10;
    private float Y_CARD_POSITION = -3.5f;

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
        for (int cardIndex = 0; cardIndex < cards.Count; ++cardIndex)
        {
            MoveCardAt(cardIndex);
        }
    }

    void MoveCardAt(int cardIndex)
    {
        cards[cardIndex].transform.localPosition = CalcPositionAt(cardIndex);
    }

    Vector3 CalcPositionAt(int cardIndex)
    {
        float positionOffset = CalcPositionOffsetAt(cardIndex);
        return new Vector3(CalcX(positionOffset), CalcY(), CalcZ(cardIndex));
    }

    float CalcPositionOffsetAt(int index) { return index - ((float)cards.Count - 1) / 2; }

    float CalcX(float positionOffset) { return Mathf.Sin(positionOffset * Mathf.Deg2Rad) * CARD_SPACING * 10; }

    float CalcY() { return Y_CARD_POSITION; }

    float CalcZ(int index) { return cards.Count - index; }
}
