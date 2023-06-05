using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCard : Card
{
    private readonly Vector3 TAPPED_POSITION = new(0, 0, -90);
    private readonly Vector3 UNTAPPED_POSITION = new(0, 0, 0);

    public void Tap()
    {
        isTapped = true;
        transform.eulerAngles = TAPPED_POSITION;
    }

    public void UnTap()
    {
        isTapped = false;
        transform.eulerAngles = UNTAPPED_POSITION;
    }

    public void IncreaseDamage(int damage)
    {
        foreach (var effect in cardInfo.effects)
        {
            if (effect is DealDamage)
            {
                var dealDamage = effect as DealDamage;
                dealDamage.damage += damage;
                SetText();
                return;
            }
        }
    }

}
