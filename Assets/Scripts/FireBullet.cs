using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;

    [SerializeField] float bulletTime;
    [SerializeField] float remainTime;
    

    [Range(1,10)]
    [SerializeField] float bulletSpeed;

    private void Start()
    {
        
    }

    public void Update()
    {
        if ((Input.GetButtonDown("Fire1")))
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        bullet.SetSpeed(bulletSpeed);
    }
}
