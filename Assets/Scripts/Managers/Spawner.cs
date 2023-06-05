using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Card cardPrefab;
    public WeaponCard weaponCardPrefab;

    public Card SpawnCard(CardInfo cardInfo)
    {
        Card newCard = Instantiate(cardPrefab, transform);
        newCard.SetCardInfo(cardInfo);
        return newCard;
    }

    public WeaponCard SpawnWeaponCard(CardInfo cardInfo)
    {
        WeaponCard newCard = Instantiate(weaponCardPrefab, transform);
        newCard.SetCardInfo(cardInfo);
        return newCard;
    }

}