using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    [SerializeField]Rigidbody2D bulletPrefab; 
    [SerializeField]int poolSize = 25; 
    
    [SerializeField]private Queue<Rigidbody2D> bulletPool; 

    void Awake()
    {
        instance = this;
        bulletPool = new Queue<Rigidbody2D>();

        for (int i = 0; i < poolSize; i++)
        {
            ReturnBullet(Instantiate(bulletPrefab));
        }
    }

    public Rigidbody2D GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            Rigidbody2D bullet = bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
            bullet.transform.parent = null;
            return bullet;
        }

        Rigidbody2D newBullet = Instantiate(bulletPrefab);
        return newBullet;
    }

    public void ReturnBullet(Rigidbody2D bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.parent = transform;
        bullet.velocity = Vector2.zero;
        bullet.angularVelocity = 0;
        bulletPool.Enqueue(bullet);
    }
}
