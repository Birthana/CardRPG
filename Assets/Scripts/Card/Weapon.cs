using UnityEngine;

public class Weapon : MonoBehaviour
{
    public CardInfo weaponInfo;
    [SerializeField] private WeaponCard weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon.SetCardInfo(weaponInfo);
    }

    public WeaponCard GetWeapon() { return weapon; }
    public void SetWeapon(WeaponCard newWeapon) { weapon = newWeapon; }

    public void UnTap()
    {
        var weapon = GetWeapon();
        weapon.UnTap();
    }
}
