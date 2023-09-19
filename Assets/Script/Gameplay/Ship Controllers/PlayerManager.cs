using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (WeaponController))]
[RequireComponent(typeof(PlayerMovementController))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public GameManager GetGameManager() => gameManager;

    #region Power Up Mechanics

    private List<IPowerUp> powerUpListners = new List<IPowerUp>();

    private IPowerUp activePowerUp;

    public void Register_PowerUpListners(IPowerUp iPowerUp)
    {
        if (!powerUpListners.Contains(iPowerUp))
            powerUpListners.Add(iPowerUp);
        else
            Debug.LogError("Already register this event!!!");    
    }

    void CheckPowerUp(PowerUp newPowerUp)
    {
        bool didWeFindPowerUp = false;
        print("Active Listerner Count: " + powerUpListners.Count + " ,searching for  :" + newPowerUp.PowerUpType);

        for (int i = 0; i < powerUpListners.Count; i++)
        {
            print("Active Listerner : " + powerUpListners[i].powerType);
            if (powerUpListners[i].powerType == newPowerUp.PowerUpType)
            {
                print("foudn the power Match ");
                ActivatePower(powerUpListners[i], newPowerUp);
                didWeFindPowerUp = true;
                break;
            }
        }
        if (!didWeFindPowerUp)
            Debug.LogError("Didn't find the power in listerners list :" + newPowerUp.name);
    }   
    

    void ActivatePower(IPowerUp targetComponent , PowerUp power)
    {
        DeactivatePower();
        activePowerUp = targetComponent;
        activePowerUp.ActivatePower(power.AssociatedData);
        Invoke("DeactivatePower", power.Duration);
    }

    void DeactivatePower()
    {
        CancelInvoke("DeactivatePower");
        if(activePowerUp != null)
            activePowerUp.DeactivatePower();
        activePowerUp = null;
    }


    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigered from :" );
        if (collision.CompareTag("PowerUp"))
        {
            PowerUp power = collision.GetComponent<PowerUp>();
            if (power != null)            
                CheckPowerUp(power);            
            else
                Debug.LogError("Didn't find the power Interface on this collided object :" + collision.name);

            Destroy(collision.gameObject);
        }
    }
}
