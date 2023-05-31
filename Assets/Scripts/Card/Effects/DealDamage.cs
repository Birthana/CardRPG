using System;
using UnityEngine;

[Serializable]
public class DealDamage : Effect
{
    public int damage;
    public Element damageType;

    public DealDamage() { }
    
    public DealDamage(Target target) : base(target)
    {
    }

    public DealDamage(int newDamage) 
    {
        damage = newDamage;
        damageType = Element.Weapon;
    }

    public DealDamage(int newDamage, Element newDamageType) 
    {
        damage = newDamage;
        damageType = newDamageType;

    }

    public override void Cast()
    {
        Enemy selectedEnemy = GetTarget().GetTarget();
        var health = selectedEnemy.GetComponent<Health>();
        health.TakeDamage(damage, damageType);
    }

    public override string GetDescription()
    {
        return $"Deal <color=green>{damage}</color> damage{GetTarget().GetDesciption()}";
    }
}
