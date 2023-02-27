using UnityEngine;

public class AddCardToHand : Effect
{
    public GameObject cardToSpawn;

    public override void Cast(Enemy target)
    {
        Spawner spawner = FindObjectOfType<Spawner>();
        spawner.Spawn(cardToSpawn);
    }

    public override string GetDescription()
    {
        return $"Add {cardToSpawn.name} to hand.";
    }
}
