using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship MovementData", menuName = "Game/Ship Movement", order = 2)]
public class So_MovementData : ScriptableObject
{
    public float rotationSpeed = 250.0f;
    public float maxSpeed = 8.0f;
    public float accelerationRate = 5.0f; // Adjust this value to control acceleration
    public float decelerationRate = 4.0f; // Adjust this value to control deceleration
}
