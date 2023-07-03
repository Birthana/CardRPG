using System;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private List<FieldCard> monsters = new List<FieldCard>();

    public FieldCard GetCardAt(int position)
    {
        return monsters[position];
    }

    public void Add(FieldCard monster, MonsterStats stats)
    {
        var newMonster = Instantiate(monster, transform);
        monsters.Add(newMonster);
        var fieldCard = newMonster.GetComponent<FieldCard>();
        fieldCard.SetUI(stats);
        var character = Player.FindCharacter();
        character.SetStartOfTurnEffect(fieldCard.UnTap);
        DisplayHand();
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
