using System;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public event Action OnWeaponHit;
    public TextMeshPro healthDisplay;
    public int maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthDisplay.text = $"{currentHealth}";
    }

    public void TakeDamage(int damage, Element element)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        healthDisplay.text = $"{currentHealth}";
        if (element == Element.Weapon)
        {
            OnWeaponHit?.Invoke();
        }
    }
}
