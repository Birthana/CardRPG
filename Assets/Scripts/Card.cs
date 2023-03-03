using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Element { None, Fire, Water, Earth, Wind, Lightning, Void }

    public enum Weapon { Sword, Hammer, Pickaxe, Arrow, Dagger, Shield, Bag, None }

    public Element element;
    public Weapon weapon;
    private Effect[] effects;
    private Target[] targets;

    private void Awake()
    {
        effects = GetComponents<Effect>();
        targets = GetComponents<Target>();
    }

    public Target[] GetTargets() { return targets; }

    public void Cast()
    {
        foreach (var effect in effects)
        {
            var target = effect.GetTarget() as SingleEnemy;
            effect.Cast(target.GetTarget().GetComponent<Enemy>());
        }
    }
}
