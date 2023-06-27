using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private List<GameObject> monsters = new List<GameObject>();

    public void Add(GameObject monster, MonsterStats stats)
    {
        var newMonster = Instantiate(monster, transform);
        monsters.Add(newMonster);
        var fieldCard = newMonster.GetComponent<FieldCard>();
        fieldCard.SetUI(stats);
    }
}
