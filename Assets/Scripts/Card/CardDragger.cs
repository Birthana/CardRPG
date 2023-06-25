public class CardDragger
{
    private Card selectedCard;

    public Card Get() { return selectedCard; }

    public bool CharacterCanCastCard() 
    {
        var character = Player.FindCharacter();
        return character.GetEnergy().HasActions(selectedCard.GetActionCost()) && !selectedCard.IsTapped();
    }

    public void PickUpCard() { selectedCard = Mouse.GetHitComponent<Card>(); }

    public void CastSelectedCard()
    {
        var character = Player.FindCharacter();
        character.GetEnergy().UseActions(selectedCard.GetActionCost());
        selectedCard.Cast();
        var hand = Player.FindHand();
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
