using UnityEngine;

public class Hover
{
    private float HOVERED_Z_POSITION = 0.0f;
    private Card hovered;
    private Vector3 previousPosition;

    public void ResetHoveredCard()
    {
        if (hovered == null)
        {
            return;
        }

        SetPosition(hovered, previousPosition);
        SetHoveredCard(null);
    }

    public void RaiseCard()
    {
        var card = Mouse.GetHitComponent<Card>();
        if (hovered == card)
        {
            return;
        }

        ResetHoveredCard();
        SetHoveredCard(card);
        var position = card.gameObject.transform.position;
        SetPosition(hovered, new Vector3(position.x, position.y, HOVERED_Z_POSITION));
    }

    private void SetHoveredCard(Card card) 
    {
        previousPosition = (card == null) ? Vector3.zero : card.gameObject.transform.position;
        hovered = card;
    }

    private void SetPosition(Card card, Vector3 position) { card.gameObject.transform.position = position; }
}
