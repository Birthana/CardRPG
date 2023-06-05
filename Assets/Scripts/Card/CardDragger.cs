using System.Collections;
using UnityEngine;

public class CardDragger : MonoBehaviour
{
    private Card selectedCard;
    private Hand hand;
    private Character character;
    private TurnManager turnManager;

    private void Start()
    {
        hand = FindObjectOfType<Hand>();
        character = FindObjectOfType<Character>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void Update()
    {
        if (!turnManager.IsPlayerTurn())
        {
            return;
        }

        if (Mouse.PlayerPressesLeftClick())
        {
            PickUpCard();
        }
    }

    private void PickUpCard()
    {
        if (Mouse.IsOnHandLayer())
        {
            selectedCard = Mouse.GetHitObject().GetComponent<Card>();
            if (character.HasActions(selectedCard.GetActionCost()) && !selectedCard.IsTapped())
            {
                StartCoroutine(selectedCard.Targeting(CastSelectedCard));
            }
        }
    }

    private void CastSelectedCard()
    {
        character.UseActions(selectedCard.GetActionCost());
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
