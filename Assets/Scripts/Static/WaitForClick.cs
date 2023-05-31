using System;
using System.Collections;

public static class WaitForClick
{
    public static IEnumerator TriggerOnLeftClick(Action functionCall)
    {
        bool targeting = true;
        while (targeting)
        {
            if (Mouse.PlayerReleasesLeftClick())
            {
                targeting = false;
                functionCall();
            }

            yield return null;
        }
    }

    public static IEnumerator HoldingOnLeftClick(Action functionCall)
    {
        bool targeting = true;
        while (targeting)
        {
            functionCall();
            if (Mouse.PlayerReleasesLeftClick())
            {
                targeting = false;
            }

            yield return null;
        }
    }
}
