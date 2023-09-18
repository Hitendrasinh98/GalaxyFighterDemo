using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game/Weapon/New Weapon", order = 0)]
public class So_Weapon : ScriptableObject
{
    [SerializeField] string id;
    [SerializeField] BaseWeapon prefab_Weapon;
    [SerializeField] So_WeaponData weaponData;

    public string Id => id;

    public IBaseWeapon GetWeapon()
    {
        BaseWeapon newWeapon = Instantiate(prefab_Weapon);
        newWeapon.InitiazeWeaponData(weaponData);
        return newWeapon;
    }
}
