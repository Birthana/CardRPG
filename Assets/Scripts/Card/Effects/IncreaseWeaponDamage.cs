public class IncreaseWeaponDamage : Effect
{
    public int increasedDamage;

    public IncreaseWeaponDamage() : base(new NoTarget()) { }

    public IncreaseWeaponDamage(Target target) : base(target) { }

    public override void Cast()
    {
        var weapon = Player.FindWeapon();
        var card = weapon.GetWeapon();
        card.IncreaseDamage(increasedDamage);
    }

    public override string GetDescription()
    {
        return $"Increase your weapon damage by <color=blue>{increasedDamage}</color>{GetTarget().GetDesciption()}";
    }
}
