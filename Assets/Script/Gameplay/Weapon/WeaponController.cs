using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour , IPowerUp
{

   
   
    [Header("Current Progress")]
    [SerializeField]private IBaseWeapon activeWeapon;

    [Header("Testing Purpose")]
    [SerializeField] So_Weapon test_Weapon;

    private PlayerManager playerManager;    
    private IBaseWeapon defaultWeapon;
    private IBaseWeapon powerUpWeapon;

    public PowerUpType powerType => PowerUpType.Weapon;

    


    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        Register_PowerUpListners();
        LoadDefaultWeapon();
    }

    void Register_PowerUpListners()
    {
        if (playerManager == null)
            Debug.LogError("We got an issue here, Null Manager");
        playerManager.Register_PowerUpListners(this);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            activeWeapon.Shoot();
        }
    }


    void LoadDefaultWeapon()
    {
        if(defaultWeapon == null)
            defaultWeapon = playerManager.GetGameManager().GetDefaultWeapon();
        InitializeWeapon(defaultWeapon);
    }

    void InitializeWeapon(IBaseWeapon weapon)
    {
        if(activeWeapon != null)
            activeWeapon.gameObject.SetActive(false);

        weapon.gameObject.transform.parent = transform;
        weapon.gameObject.transform.localPosition = Vector3.zero;
        weapon.gameObject.transform.localRotation = Quaternion.identity;

        activeWeapon = weapon;
        activeWeapon.gameObject.SetActive(true);

    }












    public void ActivatePower(ScriptableObject data)
    {
        Debug.Log("PowerUp : Activating weapon Power -" + data.name);
        So_Weapon weapon = (So_Weapon)data;
        if (weapon != null)
        {
            powerUpWeapon = weapon.GetWeapon();
            InitializeWeapon(powerUpWeapon);
        }
        else
            Debug.LogError("Some issue is here in this powerUp :" + powerType + " ," + data.name);

    }

    public void DeactivatePower()
    {
        Debug.Log("PowerUp : DeActivating Weapon Power" );
        if (powerUpWeapon != null)
        {
            Destroy(powerUpWeapon.gameObject);
            powerUpWeapon = null;
        }

        LoadDefaultWeapon();
    }



    [ContextMenu("Test Weapon")]
    void TestNewWeapon()
    {
        if (test_Weapon == null)
        {
            Debug.LogError("Null test weapon data");
            return;
        }
        Debug.Log("Testing this gun :" + test_Weapon.Id);
        ActivatePower(test_Weapon);
    }
}
