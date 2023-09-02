using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseWeapon 
{
    public string Id { get; }
    void Shoot();
    So_WeaponData WeaponData { get; }

    GameObject gameObject { get; }
}
