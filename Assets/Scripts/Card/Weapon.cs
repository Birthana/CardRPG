using UnityEngine;

public class Weapon : MonoBehaviour
{
    public CardInfo weaponInfo;
    [SerializeField] private Card weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon.SetCardInfo(weaponInfo);
    }

    public Card GetWeapon() { return weapon; }
    public void SetWeapon(Card newWeapon) { weapon = newWeapon; }
}
