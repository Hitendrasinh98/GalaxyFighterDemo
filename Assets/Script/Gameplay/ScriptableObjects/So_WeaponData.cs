using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game/Weapon/WeaponData",order =1)]
public class So_WeaponData : ScriptableObject
{
    public int bulletsPerBurst = 3;
    public float fireRate = 0.25f;
    public float coolDown = 1f;
    public int bulletSpeed = 25;

    
}
