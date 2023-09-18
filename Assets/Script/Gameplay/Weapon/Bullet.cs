using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke("Dispose", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dispose();
    }

    void Dispose()
    {
        CancelInvoke("Dispose");
        if(gameObject.activeInHierarchy)
            BulletPool.instance.ReturnBullet(rb);
    }
}
