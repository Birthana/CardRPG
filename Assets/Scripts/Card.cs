using System.Collections;
using UnityEngine;

public enum Element { None, Fire, Water, Earth, Wind, Lightning, Void }
public enum Weapon { Sword, Hammer, Pickaxe, Arrow, Dagger, Shield, Bag, None }

public class Card : MonoBehaviour
{
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
            var target = effect.GetTarget();
            var targets = target.GetTarget();
            foreach (var selectedTarget in targets)
            {
                effect.Cast(selectedTarget.GetComponent<Enemy>());
            }
        }
    }
}
