using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTargetType : CardTargetType
{
    public override IEnumerator RunTargetingAs(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(SingleEffectTriggerTargetType(targets, castFunction));
    }

    public IEnumerator SingleEffectTriggerTargetType(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(SingleTarget(targets[1]));

        if (targets[1].IsCanceled())
        {
            yield break;
        }

        castFunction();
    }

    private IEnumerator SingleTarget(Target target)
    {
        Line.SetStartPosition(Mouse.GetHitPosition());
        StartCoroutine(Line.SetEndPositionToMouse());
        yield return StartCoroutine(target.Targeting());
        Line.ResetPosition();
    }
}
