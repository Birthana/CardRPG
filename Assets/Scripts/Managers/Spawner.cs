using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Card cardPrefab;

    public Card SpawnCard(CardInfo cardInfo)
    {
        Card newCard = Instantiate(cardPrefab, transform);
        newCard.SetCardInfo(cardInfo);
        return newCard;
    }
}