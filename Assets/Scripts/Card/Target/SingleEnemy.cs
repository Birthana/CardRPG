using System;
using System.Collections;

[Serializable]
public class SingleEnemy : Target
{
    private Enemy target;

    public SingleEnemy() : base() {}

    public override bool IsCanceled() { return GetTarget() == null; }

    public override Enemy GetTarget() { return target; }

    public override IEnumerator Targeting()
    {
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
