using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp
{
    public PowerUpType powerType { get; }
    void ActivatePower(ScriptableObject data);

    void DeactivatePower();
}
