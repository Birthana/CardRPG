using UnityEngine;

[RequireComponent(typeof(Card))]
[RequireComponent(typeof(DealDamage))]
public class ApplyMarker : Effect
{
    public int sameElementDamage;
    public int differentElementDamage;
    private Card.Element element;

    private void Start()
    {
        var info = GetComponent<Card>();
        element = info.element;
    }

    public override void Cast(Enemy target)
    {
        var marker = target.GetMarker();
        if (MarkerIsNone(marker))
        {
            target.SetMarker(element);
            return;
        }

        var health = target.GetComponent<Health>();

        if (MarkerIsSame(marker))
        {
            health.TakeDamage(sameElementDamage);
            target.SetMarker(Card.Element.None);
            return;
        }

        health.TakeDamage(differentElementDamage);
        target.SetMarker(element);
    }

    private bool MarkerIsNone(Card.Element marker) { return marker == Card.Element.None; }
    private bool MarkerIsSame(Card.Element marker) { return marker == element; }

    public override string GetDescription()
    {
        return $"Apply {element}.";
    }
}
