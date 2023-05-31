using System;
using System.Collections;
using UnityEngine;

public class Line : MonoBehaviour
{
    private static LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public static void SetStartPosition(Vector2 position) { line.SetPosition(0, position); }
    public static void SetEndPosition(Vector2 position) { line.SetPosition(1, position); }
    public static void ResetPosition()
    {
        SetStartPosition(Vector2.zero);
        SetEndPosition(Vector2.zero);
    }

    public void FollowMouse()
    {
        StartCoroutine(SetEndPositionToMouse());
    }

    public static IEnumerator SetEndPositionToMouse()
    {
        yield return WaitForClick.HoldingOnLeftClick(SetEndPositionToCurrentMousePosition);
    }

    private static void SetEndPositionToCurrentMousePosition()
    {
        SetEndPosition(Mouse.GetPosition());
    }
}
