using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [Header("Testing Purpose")]
    [SerializeField] string test_WeaponId;
   
    private IBaseWeapon activeWeapon;


    private void Start()
    {
        SwitchWeapon("Default");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            activeWeapon.Shoot();
        }
    }


    

    public void SwitchWeapon(string _newWeaponId = "")
    {
        if(activeWeapon != null && activeWeapon.gameObject)
            Destroy(activeWeapon.gameObject);

        BaseWeapon newWeapon = gameManager.GetWeaponById(_newWeaponId);
        IBaseWeapon weapon = Instantiate(newWeapon, transform);
        weapon.gameObject.transform.localPosition = Vector3.zero;
        weapon.gameObject.transform.localRotation = Quaternion.identity;

        activeWeapon = weapon;

    }





    [ContextMenu("Change Weapon")]
    void TestNewWeapon()
    {
        SwitchWeapon(test_WeaponId);
    }
}
