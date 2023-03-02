using System.Collections;
using UnityEngine;

public abstract class Target : ScriptableObject
{
    public abstract GameObject GetTarget();

    public abstract IEnumerator Targeting();
}
