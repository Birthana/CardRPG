public class CardDragger
{
    private Card selectedCard;
    private readonly Hand hand;
    private readonly Energy energy;

    public CardDragger(Hand hand, Energy energy)
    {
        this.hand = hand;
        this.energy = energy;
    }

    public Card Get() { return selectedCard; }

    public bool CharacterCanCastCard() 
    {
        return energy.HasActions(selectedCard.GetActionCost()) && !selectedCard.IsTapped();
    }

    public void PickUpCard() { selectedCard = Mouse.GetHitComponent<Card>(); }

    public void CastSelectedCard()
    {
        energy.UseActions(selectedCard.GetActionCost());
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
