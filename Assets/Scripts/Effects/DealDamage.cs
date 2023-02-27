using UnityEngine;

public class DealDamage : Effect
{
    public int damage;

    public override void Cast(Enemy target)
    {
        var health = target.GetComponent<Health>();
        health.TakeDamage(damage);
    }

    public override string GetDescription()
    {
        return $"Deal {damage} damage.";
    }
}
