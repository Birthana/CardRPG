using System.Collections.Generic;
using UnityEngine;

public class CardInformation : MonoBehaviour
{
    public enum Element { None, Fire, Water, Earth, Wind, Lightning, Void }

    public enum Weapon { Sword, Hammer, Pickaxe, Arrow, Dagger, Shield, Bag, None }

    public Element element;
    public Weapon weapon;
    private List<Effect> effects = new List<Effect>();

    private void Start()
    {
        Effect[] effectsOnObject = GetComponents<Effect>();
        foreach (var effect in effectsOnObject)
        {
            effects.Add(effect);
        }
    }

    public void Cast(Enemy selectedTarget)
    {
        foreach (var effect in effects)
        {
            effect.Cast(selectedTarget);
        }
    }
}
