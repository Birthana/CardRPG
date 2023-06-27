using UnityEngine;
using TMPro;

public class FieldCard : MonoBehaviour
{
    public TextMeshPro healthUI;
    public TextMeshPro attackUI;

    public void SetUI(MonsterStats stats)
    {
        healthUI.text = $"{stats.health}";
        attackUI.text = $"{stats.attack}";
    }
}
