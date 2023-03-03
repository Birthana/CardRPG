using System.Collections;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    public abstract GameObject GetTarget();

    public abstract IEnumerator Targeting();
}
