public class TriggerCheck : Effect
{
    public int increasedDamage;
    public Element element;

    public TriggerCheck() : base(new NoTarget()) { }

    public TriggerCheck(Target target) : base(target) { }

    public override void Cast()
    {
        var character = Player.FindCharacter();
        var deck = character.GetComponent<Deck>();
        var card = deck.Draw();
        if (card.trigger && card.element == element)
        {
            var weapon = Player.FindWeapon();
            var weaponCard = weapon.GetWeapon();
            weaponCard.IncreaseDamage(increasedDamage);
        }
    }

    public override string GetDescription()
    {
        return $"";
    }
}
