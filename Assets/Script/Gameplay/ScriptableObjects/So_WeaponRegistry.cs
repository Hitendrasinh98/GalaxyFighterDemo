using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Registry", menuName = "Game/Registry/Weapon Registry", order =1)]
public class So_WeaponRegistry : ScriptableObject
{
    [SerializeField] List<So_Weapon> availableWeapons;


    public IBaseWeapon GetWeaponById(string _weaponId)
    {
        for (int i = 0; i < availableWeapons.Count; i++)
        {
            if(availableWeapons[i].Id == _weaponId)
            {
                return availableWeapons[i].GetWeapon();
            }
        }

        Debug.LogError("Didn't find any Weapon :" + _weaponId);
        return null;
    }
}
