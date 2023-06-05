using UnityEngine;

public class Player : MonoBehaviour
{
    public static Hand FindHand() { return FindObjectOfType<Hand>(); }

    public static Weapon FindWeapon() { return FindObjectOfType<Weapon>(); }

    public static Character FindCharacter() { return FindObjectOfType<Character>(); }

    public static Field FindField() { return FindObjectOfType<Field>(); }

    public static TimeManager FindTimeManager() { return FindObjectOfType<TimeManager>(); }

    public static Spawner FindSpawner() { return FindObjectOfType<Spawner>(); }
}
