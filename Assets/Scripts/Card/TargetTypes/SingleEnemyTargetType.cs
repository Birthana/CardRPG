using System;
using System.Collections;

public class SingleEnemyTargetType : CardTargetType
{
    public override IEnumerator RunTargetingAs(Target[] targets, Action castFunction)
    {
        yield return StartCoroutine(SingleEffectSingleTarget(targets, castFunction));
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

    private IEnumerator SingleTarget(Target target)
    {
        Line.SetStartPosition(Mouse.GetHitPosition());
        StartCoroutine(Line.SetEndPositionToMouse());
        yield return StartCoroutine(target.Targeting());
        Line.ResetPosition();
    }
}
