using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Prefab References")]
    public Bullet bulletPrefab;

    [Header("Gun Settings")]
    public float fireRate = 0.5f;

    bool isShoot;
    float nextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireRate();
    }

    //Maintains the fire rate of the gun
    void FireRate()
    {
        if (isShoot && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    //Shooting a bullet
    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetBulletTarget(true);
    }

    //Used to set the shooting state
    public void TopggleShooting(bool shoot)
    {
        isShoot = shoot;
    }
}
