using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPrefab2;
    [SerializeField] GameObject bulletPrefab3;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Bullet bullet = instance.GetComponent<Bullet>();
            Fire();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject instance = Instantiate(bulletPrefab2, muzzlePoint.position, muzzlePoint.rotation);
            Bullet bullet = instance.GetComponent<Bullet>();
            Fire2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject instance = Instantiate(bulletPrefab3, muzzlePoint.position, muzzlePoint.rotation);
            Bullet bullet = instance.GetComponent<Bullet>();
            Fire3();
        }
    }

    public void Fire()
    {
        
        bullet.SetSpeed(bulletSpeed);
    }

    public void Fire2()
    {
        
        bullet.SetSpeed(bulletSpeed);
    }

    public void Fire3()
    {
        bullet.SetSpeed(bulletSpeed);
    }


}
