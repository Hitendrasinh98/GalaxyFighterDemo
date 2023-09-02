using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] So_WeaponRegistry so_WeaponRegistry;


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public BaseWeapon GetWeaponById(string _weaponId) => so_WeaponRegistry.GetWeaponById(_weaponId);
    
}
