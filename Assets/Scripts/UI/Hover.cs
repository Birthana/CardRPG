using UnityEngine;

public class Hover : MonoBehaviour
{
    public float HOVERED_Z_POSITION;
    private Card hovered;
    private Vector3 previousPosition;
    private CardDragger dragger;

    private void Start()
    {
        dragger = FindObjectOfType<CardDragger>();
    }

    private void Update()
    {
        // TODO: Don't hover while dragging.
        if (Mouse.IsOnHandLayer())
        {
            RiseCard();
        }
    }

    public void ResetHoveredCard()
    {
        SetPosition(hovered, previousPosition);
        SetHoveredCard(null);
    }

    private void RiseCard()
    {
        if(hovered != null)
        {
            ResetHoveredCard();
        }
        var card = Mouse.GetHitComponent<Card>();
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
