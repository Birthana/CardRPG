using System;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public event Action OnWeaponHit;
    public event Action OnDeath;
    public TextMeshPro healthDisplay;
    public int maxHealth;
    private int currentHealth;

    void Start()
    {
        SetHealth(maxHealth);
    }

    public Health SetMaxHealth(int health)
    {
        maxHealth = health;
        return this;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        healthDisplay.text = $"{currentHealth}";
    }

    public bool IsDead() { return currentHealth == 0; }

    public void TakeDamage(int damage, Element element)
    {
        SetHealth(Mathf.Max(0, currentHealth - damage));
        if (element == Element.Weapon)
        {
            OnWeaponHit?.Invoke();
        }

        if (IsDead())
        {
            OnDeath?.Invoke();
        }
    }
}
