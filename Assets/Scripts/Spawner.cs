using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Card> cardToSpawn = new List<Card>();
    public List<int> numbersOfCardsToSpawn = new List<int>();
    private List<Card> spawned = new List<Card>();
    private int CARD_SPACING = 10;

    void Start()
    {
        SpawnMore();
    }

    public void SpawnMore()
    {
        for (int i = 0; i < cardToSpawn.Count; i++)
        {
            for (int j = 0; j < numbersOfCardsToSpawn[i]; j++)
            {
                Spawn(cardToSpawn[i]);
            }
        }
    }

    public void Spawn(Card cardToSpawn)
    {
        Card newCard = Instantiate(cardToSpawn, transform);
        spawned.Add(newCard);
        DisplayHand();
    }

    public void DestroySpawnedCard(Card selectedCard)
    {
        spawned.Remove(selectedCard);
        Destroy(selectedCard.gameObject);
        DisplayHand();
    }

    void DisplayHand()
    {
        for (int cardIndex = 0; cardIndex < spawned.Count; ++cardIndex)
        {
            MoveCardAt(cardIndex);
        }
    }

    void MoveCardAt(int cardIndex)
    {
        spawned[cardIndex].transform.localPosition = CalcPositionAt(cardIndex);
    }

    Vector3 CalcPositionAt(int cardIndex)
    {
        float positionOffset = CalcPositionOffsetAt(cardIndex);
        return new Vector3(CalcX(positionOffset), CalcY(), CalcZ(cardIndex));
    }

    float CalcPositionOffsetAt(int index) { return index - ((float)spawned.Count - 1) / 2; }

    float CalcX(float positionOffset) { return Mathf.Sin(positionOffset * Mathf.Deg2Rad) * CARD_SPACING * 10; }

    float CalcY() { return 0; }

    float CalcZ(int index) { return spawned.Count - index; }
}
