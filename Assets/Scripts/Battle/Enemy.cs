using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Loot
{
    public CardInfo card;
    public int percentage;
}

public struct RandomCard
{
    public CardInfo card;
    public int range;

    public RandomCard(CardInfo newCard, int newRange)
    {
        card = newCard;
        range = newRange;
    }
}

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public List<Loot> lootTable;
    private Hand hand;
    private List<RandomCard> rngLoot = new List<RandomCard>();

    public void Start()
    {
        hand = FindObjectOfType<Hand>();
        var health = GetComponent<Health>();
        health.OnWeaponHit += DropLoot;

        SetUpRanges();
    }

    private void SetUpRanges()
    {
        int range = 0;
        foreach (var loot in lootTable)
        {
            range += loot.percentage;
            var rngCard = new RandomCard(loot.card, range);
            rngLoot.Add(rngCard);
        }

        if(range > 100)
        {
            Debug.LogError("Percentage of Loot Greater than 100.");
        }
    }

    public void DropLoot()
    {
        int rngIndex = GetRandomCardIndex();
        CardInfo card = GetCardFrom(rngIndex);
        hand.Add(card);
    }

    private int GetRandomCardIndex() { return UnityEngine.Random.Range(0, 100); }

    private CardInfo GetCardFrom(int rngIndex)
    {
        foreach (var loot in rngLoot)
        {
            if(rngIndex < loot.range)
            {
                return loot.card;
            }
        }

        return null;
    }
}
