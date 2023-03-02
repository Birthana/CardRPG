using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleEnemy", menuName = "Target/SingleEnemy")]
public class SingleEnemy : Target
{
    private GameObject target;

    public override GameObject GetTarget() { return target; }

    public override IEnumerator Targeting()
    {
        target = Mouse.GetHitObject();
        yield return null;
    }
}
