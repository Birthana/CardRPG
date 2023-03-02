using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Element { None, Fire, Water, Earth, Wind, Lightning, Void }

    public enum Weapon { Sword, Hammer, Pickaxe, Arrow, Dagger, Shield, Bag, None }

    public Element element;
    public Weapon weapon;
    private Effect[] effects;

    private Line line;

    private void Awake()
    {
        effects = GetComponents<Effect>();
        line = FindObjectOfType<Line>();
    }

    public IEnumerator Casting()
    {
        foreach (var effect in effects)
        {
            var target = effect.GetTarget();
            yield return StartCoroutine(target.Targeting());
            effect.Cast(target.GetTarget().GetComponent<Enemy>());
            line.ResetPosition();
        }
    }
}
