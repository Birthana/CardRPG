using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private List<FieldCard> monsters = new List<FieldCard>();

    public bool HasMonsters() { return monsters.Count != 0; }

    public FieldCard GetRandomMonster()
    {
        var rng = Random.Range(0, monsters.Count);
        return monsters[rng];
    }

    public void Add(FieldCard monster, MonsterStats stats)
    {
        var newMonster = Instantiate(monster, transform);
        monsters.Add(newMonster);
        var fieldCard = newMonster.GetComponent<FieldCard>();
        fieldCard.SetUI(stats);
        Player.FindCharacter().SetStartOfTurnEffect(fieldCard.UnTap);
        DisplayHand();
    }

    public void Remove(FieldCard monster)
    {
        monsters.Remove(monster);
        monster.Destroy();
    }

    void DisplayHand()
    {
        var positions = new CenterPosition(monsters.Count, 10);
        for (int cardIndex = 0; cardIndex < monsters.Count; ++cardIndex)
        {
            MoveCardAt(cardIndex, positions.CalcPositionAt(cardIndex));
        }
    }

    void MoveCardAt(int cardIndex, Vector3 position)
    {
        monsters[cardIndex].transform.localPosition = position;
    }
}
