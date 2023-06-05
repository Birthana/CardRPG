public class UntapWeapon : Effect
{
    public UntapWeapon() : base(new NoTarget()) { }

    public UntapWeapon(Target target) : base(target) { }

    public override void Cast()
    {
        var weapon = Player.FindWeapon();
        var card = weapon.GetWeapon();
        card.UnTap();
    }

    public override string GetDescription()
    {
        return $"Untap your weapon";
    }
}
