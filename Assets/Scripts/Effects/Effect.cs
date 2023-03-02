using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public Target target;

    public Target GetTarget() { return target; }

    public abstract void Cast(Enemy target);

    public abstract string GetDescription();
}