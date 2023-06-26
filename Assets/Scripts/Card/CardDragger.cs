public class CardDragger
{
    private Card selectedCard;
    private readonly Character character;
    private readonly Hand hand;

    public CardDragger(Character character, Hand hand)
    {
        this.character = character;
        this.hand = hand;
    }

    public Card Get() { return selectedCard; }

    public bool CharacterCanCastCard() 
    {
        return character.GetEnergy().HasActions(selectedCard.GetActionCost()) && !selectedCard.IsTapped();
    }

    public void PickUpCard() { selectedCard = Mouse.GetHitComponent<Card>(); }

    public void CastSelectedCard()
    {
        character.GetEnergy().UseActions(selectedCard.GetActionCost());
        selectedCard.Cast();
        hand.Remove(selectedCard);
        SubtractFromTime();
        selectedCard = null;
    }

    private void SubtractFromTime()
    {
        var timeManager = Player.FindTimeManager();
        timeManager.ReduceTime(1);
    }
}
