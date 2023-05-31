using UnityEngine;

public static class Mouse
{
    public static Camera camera = Camera.main;
    private static RaycastHit2D hit;

    public static bool PlayerPressesLeftClick() { return Input.GetMouseButtonDown(0); }

    public static bool PlayerHoldsLeftClick() { return Input.GetMouseButton(0); }

    public static bool PlayerReleasesLeftClick() { return Input.GetMouseButtonUp(0); }

    public static Vector2 GetPosition() { return camera.ScreenToWorldPoint(Input.mousePosition); }

    public static RaycastHit2D IsOnLayer(string layerName)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, Vector2.zero, 100, 1 << LayerMask.NameToLayer(layerName));
        return hit;
    }

    public static RaycastHit2D IsOnAnything()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, Vector2.zero);
        return hit;
    }

    public static RaycastHit2D IsOnEnemyLayer() { return IsOnLayer("Enemy"); }

    public static bool HitIs<Type>()
    {
        if (IsOnAnything())
        {
            return GetHitComponent<Type>() != null;
        }

        return false;
    }

    public static RaycastHit2D IsOnHandLayer() { return IsOnLayer("Hand"); }

    public static ComponentType GetHitComponent<ComponentType>() { return hit.transform.GetComponent<ComponentType>(); }

    public static GameObject GetHitObject() { return hit.transform.gameObject; }

    public static Vector3 GetHitPosition() 
    {
        if (IsOnAnything())
        {
            return hit.transform.position;
        }

        return Vector3.zero;
    }
}
