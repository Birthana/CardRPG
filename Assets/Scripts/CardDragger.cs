using System.Collections;
using UnityEngine;

public class CardDragger : MonoBehaviour
{
    private Card selectedCard;
    private Vector3 returnPosition;
    private Line line;
    private Spawner spawner;

    private void Start()
    {
        line = FindObjectOfType<Line>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        if (Mouse.PlayerPressesLeftClick())
        {
            PickUpCard();
        }

        if (Mouse.PlayerReleasesLeftClick())
        {
            if (selectedCard == null)
            {
                return;
            }

            TryCastCard();
            line.ResetPosition();
        }

        if (selectedCard != null)
        {
            MoveSelectedCard();
        }
    }

    private void PickUpCard()
    {
        if (Mouse.IsOnHandLayer())
        {
            selectedCard = Mouse.GetHitObject().GetComponent<Card>();
            returnPosition = selectedCard.transform.position;
            line.SetStartPosition(returnPosition);
        }
    }

    private void TryCastCard()
    {
        if (!Mouse.IsOnEnemyLayer())
        {
            ReturnSelectedCard();
            return;
        }

        StartCoroutine(Casting());
    }

    IEnumerator Casting()
    {
        yield return StartCoroutine(selectedCard.Casting());
        spawner.DestroySpawnedCard(selectedCard);
        selectedCard = null;
    }

    private void MoveSelectedCard()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectedCard.transform.position = mousePosition;
        line.SetEndPosition(mousePosition);
    }

    private void ReturnSelectedCard()
    {
        selectedCard.transform.position = returnPosition;
        selectedCard = null;
    }
}
