using Nova;
using UnityEngine;

public class UIWeaponHolder : MonoBehaviour
{
    [SerializeField] private TextBlock weaponNameBlock, weaponDamageBlock, weaponAmmoBlock, hitPercentageBlock;

    public void setUp(Unit.WeaponData InternalWeapon)
    {
        weaponNameBlock.Text = InternalWeapon.weaponName;
        weaponDamageBlock.Text = InternalWeapon.Damage;
        weaponAmmoBlock.Text = InternalWeapon.Ammo;
        hitPercentageBlock.Text = InternalWeapon.hitPercentage;
    }
}
