using System.Collections;
using UnityEngine;

public class CardDragger : MonoBehaviour
{
    private Card selectedCard;
    private Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
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
            StartCoroutine(Targeting());
        }
    }

    IEnumerator Targeting()
    {
        var targets = selectedCard.GetTargets();
        foreach (Target target in targets)
        {
            yield return StartCoroutine(target.Targeting());
            if (target.GetTarget() == null)
            {
                yield break;
            }
        }
        CastSelectedCard();
    }

    private void CastSelectedCard()
    {
        selectedCard.Cast();
        spawner.DestroySpawnedCard(selectedCard);
        selectedCard = null;
    }
}
