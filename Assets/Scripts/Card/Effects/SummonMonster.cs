using UnityEngine;

[System.Serializable]
public struct MonsterStats
{
    public int health;
    public int attack;
}

public class SummonMonster : Effect
{
    public MonsterStats stats;
    public GameObject monsterPrefab;

    public SummonMonster() : base(new NoTarget()) { }

    public SummonMonster(Target target) : base(target) { }

    public override void Cast()
    {
        var field = Player.FindField();
        field.Add(monsterPrefab);
    }

    public override string GetDescription()
    {
        return $"";
    }
}
