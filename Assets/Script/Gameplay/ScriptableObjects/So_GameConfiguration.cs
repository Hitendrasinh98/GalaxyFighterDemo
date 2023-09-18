using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "Game/Game Config", order = 0)]
public class So_GameConfiguration : ScriptableObject
{
    [SerializeField] So_MovementData defaultMovementData;
    [SerializeField] So_Weapon defaultWeapon;


    public So_MovementData GetDefaultMovementData() => defaultMovementData;
    public IBaseWeapon GetDefaultWeapon() => defaultWeapon.GetWeapon();
}
