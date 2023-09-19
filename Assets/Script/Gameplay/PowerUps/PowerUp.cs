using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpType powerType;
    [SerializeField] ScriptableObject associatedData;
    [SerializeField] int duration;


    public System.Action OnDestroyEvent;


    public PowerUpType PowerUpType => powerType;
    public ScriptableObject AssociatedData => associatedData;
    public int Duration => duration;


    private void OnDestroy()
    {
        OnDestroyEvent?.Invoke();
    }


    
}
