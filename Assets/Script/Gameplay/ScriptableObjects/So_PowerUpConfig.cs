using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp Registry", menuName = "Game/Registry/PowerUp Registry", order = 2)]

public class So_PowerUpConfig : ScriptableObject
{
    [SerializeField] float minDuration = 5f; // Minimum duration of power-up effect.
    [SerializeField] float maxDuration = 10f; // Maximum duration of power-up effect.
    [SerializeField] float spawnInterval = 20f; // Time between spawning power-ups.

    [Header("Available Powers List")]
    [SerializeField] PowerUp[] availablePowers;


    public float MinDuration  => minDuration;
    public float MaxDuration => maxDuration;
    public float SpawnInterval => spawnInterval;


    public PowerUp GetRandomPowerUp()
    {
        if (availablePowers.Length == 0)
        {
            Debug.LogWarning("No power-up prefabs defined in PowerUpConfiguration.");
            return null;
        }

        return availablePowers[Random.Range(0, availablePowers.Length)];
    }
}

public enum PowerUpType { Weapon , Movement}

