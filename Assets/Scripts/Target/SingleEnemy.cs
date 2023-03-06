using System.Collections;
using UnityEngine;

public class SingleEnemy : Target
{
    private GameObject[] targets;
    private Line line;

    public override GameObject[] GetTarget() { return targets; }

    public override IEnumerator Targeting()
    {
        line = FindObjectOfType<Line>();
        line.SetStartPosition(transform.position);
        yield return StartCoroutine(Selecting());
        line.ResetPosition();
    }

    IEnumerator Selecting()
    {
        bool targeting = true;
        while (targeting)
        {
            line.SetEndPosition(Mouse.GetPosition());
            if (Mouse.PlayerReleasesLeftClick())
            {
                targeting = false;
                targets = GetSelectedTarget();
            }

            yield return null;
        }
    }

    private GameObject[] GetSelectedTarget()
    {
        if (Mouse.IsOnEnemyLayer())
        {
            return new GameObject[]{ Mouse.GetHitObject() };
        }

        return null;
    }
}
