using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardInfo")]
public class CardInfo : ScriptableObject
{
    [SerializeField] private string cardName;
    public Element element;
    public int actionCost;
    public CardTargetType cardTargetType;
    public bool trigger;
    [SerializeReference] public List<Effect> effects = new List<Effect>();

    [ContextMenu(nameof(SingleEnemyDealDamage))] void SingleEnemyDealDamage() { effects.Add(new DealDamage(new SingleEnemy())); }
    [ContextMenu(nameof(AddActions))] void AddActions() { effects.Add(new AddActions()); }
    [ContextMenu(nameof(AddCardToHand))] void AddCardToHand() { effects.Add(new AddCardToHand()); }
    [ContextMenu(nameof(ReturnWeapon))] void ReturnWeapon() { effects.Add(new ReturnWeapon()); }
    [ContextMenu(nameof(SummonMonster))] void SummonMonster() { effects.Add(new SummonMonster()); }
    [ContextMenu(nameof(IncreaseWeaponDamage))] void IncreaseWeaponDamage() { effects.Add(new IncreaseWeaponDamage()); }
    [ContextMenu(nameof(UntapWeapon))] void UntapWeapon() { effects.Add(new UntapWeapon()); }
    [ContextMenu(nameof(TriggerCheck))] void TriggerCheck() { effects.Add(new TriggerCheck()); }
    [ContextMenu(nameof(FieldCardAttack))] void FieldCardAttack() { effects.Add(new FieldCardAttack(new AttackEnemy())); }

    public string GetCardName() { return cardName; }
}
