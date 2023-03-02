using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Card.Element marker;

    public Card.Element GetMarker() { return marker; }
    public void SetMarker(Card.Element mark) { marker = mark; }


}
