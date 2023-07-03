public class FieldCardAttack : Effect
{
    public DealDamage dealDamage;

    public FieldCardAttack() : base(new NoTarget()) { }

    public FieldCardAttack(Target target) : base(target) 
    {
        dealDamage = new DealDamage(target);
    }

    public override void Cast()
    {
        dealDamage.Cast();
        var target = GetTarget() as AttackEnemy;
        var attacker = target.GetSelf() as FieldCard;
        attacker.Tap();
    }

    public override string GetDescription()
    {
        return $"";
    }
}
