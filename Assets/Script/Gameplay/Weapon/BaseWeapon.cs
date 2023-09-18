using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour, IBaseWeapon
{
    [SerializeField] Transform[] shootPoints;

    private float lastFireTime;
    private bool isBursting;

    private So_WeaponData weaponData;

    public void InitiazeWeaponData(So_WeaponData weaponData) => this.weaponData = weaponData;
    
    public void Shoot()
    {
        if (isBursting)
            return;

        // Check if enough time has passed to fire again.
        if (Time.time - lastFireTime >= weaponData.coolDown)
        {
            isBursting = true;
            BurstFire();
        }
    }

    async void BurstFire()
    {
        for (int i = 0; i < weaponData.bulletsPerBurst; i++)
        {
            for (int j = 0; j < shootPoints.Length; j++)
            {
                Rigidbody2D bullet = BulletPool.instance.GetBullet();
                bullet.transform.position = shootPoints[j].position;
                bullet.transform.rotation = shootPoints[j].rotation;

                bullet.AddForce(shootPoints[j].up.normalized * weaponData.bulletSpeed, ForceMode2D.Impulse);
            }           
            await System.Threading.Tasks.Task.Delay((int)(weaponData.fireRate * 1000));
        }

        isBursting = false;
        lastFireTime = Time.time;
    }

   

    So_WeaponData IBaseWeapon.WeaponData => weaponData;
    GameObject IBaseWeapon.gameObject => gameObject;

}
