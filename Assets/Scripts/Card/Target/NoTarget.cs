using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class NoTarget : Target
{
    private bool willCast;

    public override bool IsCanceled() { return !willCast; }

    public override Enemy GetTarget() { return null; }

    public override IEnumerator Targeting()
    {
        yield return WaitForClick.TriggerOnLeftClick(PlayCard);
    }

    private void PlayCard()
    {
        willCast = false;
        if (Mouse.IsOnLayer("Board"))
        {
            willCast = true;
        }
    }

    public override string GetDesciption() { return $"."; }
}
