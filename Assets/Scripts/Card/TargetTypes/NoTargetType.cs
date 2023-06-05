using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTargetType : CardTargetType
{
    public override IEnumerator RunTargetingAs(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(SingleEffectNoTarget(targets, castFunction));
    }

    public IEnumerator SingleEffectNoTarget(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(NoTarget(targets[0]));

        if (targets[0].IsCanceled())
        {
            yield break;
        }

        castFunction();
    }

    private IEnumerator NoTarget(Target target)
    {
        Line.SetStartPosition(Mouse.GetHitPosition());
        Line.SetEndPosition(Mouse.GetHitPosition() + Vector3.up);
        yield return StartCoroutine(target.Targeting());
        Line.ResetPosition();
    }
}
