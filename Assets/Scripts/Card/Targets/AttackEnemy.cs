using System;
using System.Collections;

[Serializable]
public class AttackEnemy : Target
{
    private Card self;
    private Enemy target;

    public AttackEnemy() : base() {}

    public override bool IsCanceled() { return GetTarget() == null; }

    public Card GetSelf() { return self; }

    public override Enemy GetTarget() { return target; }

    public override IEnumerator Targeting()
    {
        self = Mouse.GetHitComponent<Card>();
        yield return WaitForClick.TriggerOnLeftClick(ChooseEnemyTarget);
    }

    private void ChooseEnemyTarget()
    {
        target = null;

        if (Mouse.IsOnEnemyLayer())
        {
            target = Mouse.GetHitComponent<Enemy>();
        }
    }

    public override string GetDesciption() { return $"."; }
}
