using System.Collections;
using UnityEngine;

public class AllEnemies : Target
{
    private GameObject[] targets;

    public override GameObject[] GetTarget() { return targets; }

    public override IEnumerator Targeting()
    {
        bool targeting = true;
        while (targeting)
        {
            if (Mouse.PlayerReleasesLeftClick())
            {
                targeting = false;
                targets = null;
                if (Mouse.IsOnEnemyLayer())
                {
                    Enemy[] enemies = FindObjectsOfType<Enemy>();
                    targets = new GameObject[enemies.Length];
                    for (int i = 0; i < targets.Length; i++)
                    {
                        targets[i] = enemies[i].gameObject;
                    }
                }
            }

            yield return null;
        }

    }
}
