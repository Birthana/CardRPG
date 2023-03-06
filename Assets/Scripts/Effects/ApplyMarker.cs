using UnityEngine;

[RequireComponent(typeof(Card))]
[RequireComponent(typeof(DealDamage))]
public class ApplyMarker : Effect
{
    public int sameElementDamage;
    public int differentElementDamage;
    private Element element;

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
            target.SetMarker(Element.None);
            return;
        }

        health.TakeDamage(differentElementDamage);
        target.SetMarker(element);
    }

    private bool MarkerIsNone(Element marker) { return marker == Element.None; }
    private bool MarkerIsSame(Element marker) { return marker == element; }

    public override string GetDescription()
    {
        return $"Apply {element}.";
    }
}
