using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private CardInformation.Element marker;

    public CardInformation.Element GetMarker() { return marker; }
    public void SetMarker(CardInformation.Element mark) { marker = mark; }


}
