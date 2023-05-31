using System;
using System.Collections;
using UnityEngine;

public enum TargetType
{
    SingleEffectSingleTarget, TwoEffectsSingleTargetNoTarget, SingleEffectNoTarget
}

public class CardTargetType : MonoBehaviour
{
    public IEnumerator RunTargetingAs(TargetType targetType, Target[] targets, Action castFunction)
    {
        if (targetType == TargetType.SingleEffectSingleTarget)
        {
            yield return StartCoroutine(SingleEffectSingleTarget(targets, castFunction));
        }
        else if (targetType == TargetType.TwoEffectsSingleTargetNoTarget)
        {
            yield return StartCoroutine(TwoEffectsSingleTargetNoTarget(targets, castFunction));
        }
        else if (targetType == TargetType.SingleEffectNoTarget)
        {
            yield return StartCoroutine(SingleEffectNoTarget(targets, castFunction));
        }
    }

    public IEnumerator SingleEffectSingleTarget(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(SingleTarget(targets[0]));

        if (targets[0].IsCanceled())
        {
            yield break;
        }

        castFunction();
    }

    public IEnumerator TwoEffectsSingleTargetNoTarget(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(SingleEffectSingleTarget(targets, castFunction));
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

    private IEnumerator SingleTarget(Target target)
    {
        Line.SetStartPosition(Mouse.GetHitPosition());
        StartCoroutine(Line.SetEndPositionToMouse());
        yield return StartCoroutine(target.Targeting());
        Line.ResetPosition();
    }

    private IEnumerator NoTarget(Target target)
    {
        Line.SetStartPosition(Mouse.GetHitPosition());
        Line.SetEndPosition(Mouse.GetHitPosition() + Vector3.up);
        yield return StartCoroutine(target.Targeting());
        Line.ResetPosition();
    }

}
