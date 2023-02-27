using UnityEngine;

[RequireComponent(typeof(CardInformation))]
[RequireComponent(typeof(DealDamage))]
public class ApplyMarker : Effect
{
    public int sameElementDamage;
    public int differentElementDamage;
    private CardInformation.Element element;

    private void Start()
    {
        var info = GetComponent<CardInformation>();
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
            target.SetMarker(CardInformation.Element.None);
            return;
        }

        health.TakeDamage(differentElementDamage);
        target.SetMarker(element);
    }

    private bool MarkerIsNone(CardInformation.Element marker) { return marker == CardInformation.Element.None; }
    private bool MarkerIsSame(CardInformation.Element marker) { return marker == element; }

    public override string GetDescription()
    {
        return $"Apply {element}.";
    }
}
