using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void SetStartPosition(Vector2 position) { line.SetPosition(0, position); }
    public void SetEndPosition(Vector2 position) { line.SetPosition(1, position); }
    public void ResetPosition()
    {
        SetStartPosition(Vector2.zero);
        SetEndPosition(Vector2.zero);
    }
}
