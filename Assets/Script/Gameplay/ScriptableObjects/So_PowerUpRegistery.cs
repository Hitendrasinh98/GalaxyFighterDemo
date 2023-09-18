using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp Registry", menuName = "Game/Registry/PowerUp Registry", order = 2)]

public class So_PowerUpRegistery : ScriptableObject
{
    [SerializeField] PowerUp[] availablePowers;
  

}

public enum PowerUpType { Weapon , Movement}

