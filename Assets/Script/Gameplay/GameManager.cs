using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] So_GameConfiguration gameConfig;
    [SerializeField] So_WeaponRegistry so_WeaponRegistry;


    private void Awake()
    {
#if UNITY_EDITOR
        Application.targetFrameRate = 60;
#endif
    }

    public IBaseWeapon GetDefaultWeapon() => gameConfig.GetDefaultWeapon();
    public So_MovementData GetDefaultMovementData() => gameConfig.GetDefaultMovementData();


    public IBaseWeapon GetWeaponById(string _weaponId) => so_WeaponRegistry.GetWeaponById(_weaponId);

}
