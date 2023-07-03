using System;
using System.Collections;
using UnityEngine;
using TMPro;

public enum Element { Weapon, Fire, Water, Earth, Wind, Lightning, Void }

public class Card : MonoBehaviour
{
    public TextMeshPro description;
    protected CardInfo cardInfo;
    protected bool isTapped;

    public bool IsTapped() { return isTapped; }

    public CardInfo GetCardInfo()
    {
        return cardInfo;
    }

    public void SetCardInfo(CardInfo newCardInfo)
    {
        cardInfo = Instantiate(newCardInfo);
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

    public int GetActionCost() { return cardInfo.actionCost; }

    public void Cast()
    {
        for (int i = 0; i < cardInfo.effects.Count; i++)
        {
            cardInfo.effects[i].Cast();
        }
    }

    public IEnumerator Targeting(Action castFunction)
    {
        var targetTypeObject = Instantiate(cardInfo.cardTargetType);
        yield return StartCoroutine(targetTypeObject.RunTargetingAs(GetTargetsFromEffects(), castFunction));
        Destroy(targetTypeObject.gameObject);
    }
}
