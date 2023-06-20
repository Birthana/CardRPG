using System.Collections;
using UnityEngine;

public class CardDragger : MonoBehaviour
{
    private Card selectedCard;
    private Hand hand;
    private Character character;

    private void Start()
    {
        hand = FindObjectOfType<Hand>();
        character = FindObjectOfType<Character>();
    }

    private bool CharacterCanCastCard() { return character.GetEnergy().HasActions(selectedCard.GetActionCost()) && !selectedCard.IsTapped(); }

    public IEnumerator PickUpCard()
    {
        selectedCard = Mouse.GetHitComponent<Card>();
        if (CharacterCanCastCard())
        {
            yield return StartCoroutine(selectedCard.Targeting(CastSelectedCard));
        }

        yield return null;
    }

    private void CastSelectedCard()
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
