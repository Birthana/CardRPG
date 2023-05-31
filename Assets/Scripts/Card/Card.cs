using System;
using System.Collections;
using UnityEngine;
using TMPro;

public enum Element { Weapon, Fire, Water, Earth, Wind, Lightning, Void }

public class Card : MonoBehaviour
{
    private CardInfo cardInfo;
    private TextMeshPro description;

    public void IncreaseDamage(int damage)
    {
        foreach (var effect in cardInfo.effects)
        {
            if(effect is DealDamage)
            {
                var dealDamage = effect as DealDamage;
                dealDamage.damage += damage;
                SetText();
                return;
            }
        }
    }

    public CardInfo GetCardInfo()
    {
        return cardInfo;
    }

    public void SetCardInfo(CardInfo newCardInfo)
    {
        cardInfo = Instantiate(newCardInfo);
        description = GetComponentInChildren<TextMeshPro>();
        SetText();
    }

    public Target[] GetTargetsFromEffects()
    {
        Target[] targets = new Target[cardInfo.effects.Count];
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = cardInfo.effects[i].GetTarget();
        }
        return targets;
    }

    public void SetText()
    {
        description.text = "";
        foreach (Effect effect in cardInfo.effects)
        {
            description.text += $"{effect.GetDescription()}\n";
        }
    }

    public Element GetElement() { return cardInfo.element; }

    public int GetActionCost() { return cardInfo.actionCost; }

    public string GetCardName() { return cardInfo.GetCardName(); }

    public void Cast()
    {
        for (int i = 0; i < cardInfo.effects.Count; i++)
        {
            cardInfo.effects[i].Cast();
        }
    }

    public bool IsWeapon() { return cardInfo.element == Element.Weapon; }

    public IEnumerator Targeting(Action castFunction)
    {
        var cardTargetTypes = GetComponent<CardTargetType>();
        var targetType = cardInfo.targetType;
        yield return StartCoroutine(cardTargetTypes.RunTargetingAs(targetType, GetTargetsFromEffects(), castFunction));
    }
}
