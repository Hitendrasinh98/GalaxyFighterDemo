using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp Configuration", menuName = "PowerUp Configuration")]
public class So_PowerUpSpawnConfigration : MonoBehaviour
{
    public float minDuration = 5f; // Minimum duration of power-up effect.
    public float maxDuration = 10f; // Maximum duration of power-up effect.
    public float spawnInterval = 20f; // Time between spawning power-ups.
}

