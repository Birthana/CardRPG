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

}
