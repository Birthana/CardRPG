using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Element marker;

    public Element GetMarker() { return marker; }
    public void SetMarker(Element mark) { marker = mark; }


}
