using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseWeapon 
{
    void Shoot();
    So_WeaponData WeaponData { get; }

    GameObject gameObject { get; }
}
