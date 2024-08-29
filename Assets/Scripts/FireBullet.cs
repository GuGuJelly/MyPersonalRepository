using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //[SerializeField] GameObject bulletPrefab;
    //[SerializeField] GameObject bulletPrefab2;
    //[SerializeField] GameObject bulletPrefab3;
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] Transform muzzlePoint;

    [SerializeField] float bulletTime;
    [SerializeField] float remainTime;
    

    [Range(1,10)]
    [SerializeField] float bulletSpeed;
    Bullet bullet;

    private void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    public void Fire()
    {
        PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.SetSpeed(bulletSpeed);
    }

    


}
