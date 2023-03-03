using System.Collections;
using UnityEngine;

public class SingleEnemy : Target
{
    private GameObject target;

    public override GameObject GetTarget() { return target; }

    public override IEnumerator Targeting()
    {
        var line = FindObjectOfType<Line>();
        line.SetStartPosition(transform.position);
        bool targeting = true;
        while (targeting)
        {
            line.SetEndPosition(Mouse.GetPosition());
            if (Mouse.PlayerReleasesLeftClick())
            {
                targeting = false;
                if (Mouse.IsOnEnemyLayer())
                {
                    target = Mouse.GetHitObject();
                }
            }

            yield return null;
        }
        line.ResetPosition();
    }
}
