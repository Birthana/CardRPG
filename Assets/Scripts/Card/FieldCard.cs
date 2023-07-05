using UnityEngine;
using TMPro;

public class FieldCard : Card
{
    public CardInfo fieldCardInfo;
    public TextMeshPro healthUI;
    public TextMeshPro attackUI;
    private readonly Vector3 TAPPED_POSITION = new(0, 0, -90);
    private readonly Vector3 UNTAPPED_POSITION = new(0, 0, 0);

    private void Start()
    {
        SetCardInfo(fieldCardInfo);
    }

    public void SetUI(MonsterStats stats)
    {
        GetComponent<Health>().SetMaxHealth(stats.health).SetHealth(stats.health);
        healthUI.text = $"{stats.health}";
        attackUI.text = $"{stats.attack}";
    }

    public void Tap()
    {
        isTapped = true;
        transform.eulerAngles = TAPPED_POSITION;
    }

    public void UnTap()
    {
        isTapped = false;
        transform.eulerAngles = UNTAPPED_POSITION;
    }

    public bool IsDead() { return GetComponent<Health>().IsDead(); }

    public void TakeDamage(int damage, Element element)
    {
        GetComponent<Health>().TakeDamage(damage, element);
        if (IsDead())
        {
            Player.FindField().Remove(this);
        }
    }

    public void Destroy()
    {
        var character = Player.FindCharacter();
        character.RemoveStartOfTurnEffect(UnTap);
        Destroy(gameObject);
    }
}
