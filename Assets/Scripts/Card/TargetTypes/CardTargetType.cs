using System;
using System.Collections;
using UnityEngine;

public abstract class CardTargetType : MonoBehaviour
{
    public abstract IEnumerator RunTargetingAs(Target[] targets, Action castFunction);

}
