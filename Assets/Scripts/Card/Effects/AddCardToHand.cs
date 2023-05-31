public class AddCardToHand : Effect
{
    public CardInfo cardToSpawn;
    public int numberOfCards;

    public AddCardToHand() : base(new NoTarget()) { }

    public AddCardToHand(Target target) : base(target) { }

    public override void Cast()
    {
        var hand = Player.FindHand();
        for (int i = 0; i < numberOfCards; i++)
        {
            hand.Add(cardToSpawn);
        }
    }

    public override string GetDescription()
    {
        return $"Add {numberOfCards} {cardToSpawn.GetCardName()} to Hand{GetTarget().GetDesciption()}";
    }
}
