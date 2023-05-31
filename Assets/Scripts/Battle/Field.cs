using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private List<GameObject> monsters = new List<GameObject>();

    public void Add(GameObject monster)
    {
        var newMonster = Instantiate(monster, transform);
        monsters.Add(newMonster);
    }
}
