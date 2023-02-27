using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public abstract void Cast(Enemy target);

    public abstract string GetDescription();
}