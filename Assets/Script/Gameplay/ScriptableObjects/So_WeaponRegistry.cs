using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Registery", menuName = "Game/Weapon Registry",order =0)]
public class So_WeaponRegistry : ScriptableObject
{
    [SerializeField] BaseWeapon defaultWeapon;
    [SerializeField] List<BaseWeapon> availableWeapons;


    public BaseWeapon GetWeaponById(string _weaponId)
    {
        for (int i = 0; i < availableWeapons.Count; i++)
        {
            if(availableWeapons[i].Id == _weaponId)
            {
                return availableWeapons[i];
            }
        }

        Debug.LogError("Didn't find any Weapon :" + _weaponId);
        return GetDefaultWeapon();
    }


    public BaseWeapon GetDefaultWeapon() => defaultWeapon;
}
