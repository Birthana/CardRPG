public class ReturnWeapon : Effect
{
    public ReturnWeapon() : base(new NoTarget()) { }

    public ReturnWeapon(Target target) : base(target) { }

    public override void Cast()
    {
        var weapon = Player.FindWeapon();
        var spawner = Player.FindSpawner();
        var card = spawner.SpawnCard(weapon.GetWeapon().GetCardInfo());
        card.transform.position = weapon.transform.position;
        card.transform.SetParent(weapon.transform);
        weapon.SetWeapon(card);
    }

    public override string GetDescription()
    {
        return $"";
    }
}
