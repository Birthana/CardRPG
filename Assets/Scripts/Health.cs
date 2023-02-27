using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TextMeshPro healthDisplay;
    public int maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthDisplay.text = $"{currentHealth}";
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        healthDisplay.text = $"{currentHealth}";
    }
}
