using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Data References")]
    public GunData gunData;

    [Header("Component References")]
    public AudioSource sfxPlayer;

    // Gun Bullet Spawn Game Objects
    public GameObject oneShotSpawn;
    public GameObject doubleShotSpawnLeft;
    public GameObject doubleShotSpawnRight;

    bool isShoot;
    float nextFireTime;

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
            nextFireTime = Time.time + gunData.fireRate;
            Shoot();
        }
    }

    //Shooting a bullet
    void Shoot()
    {
        switch (gunData.bulletsPerShot)
        {
            case 1:
                SpawnBullet(oneShotSpawn);
                break;
            case 2:
                SpawnBullet(doubleShotSpawnLeft);
                SpawnBullet(doubleShotSpawnRight);
                break;
            default:
                break;
        }

        // Play sound effect
        sfxPlayer.Play();
    }

    void SpawnBullet(GameObject spawnPoint)
    {
        Bullet bullet = Instantiate(gunData.bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        bullet.SetBulletTarget(true, gunData.attackPower);
    }

    //Used to set the shooting state
    public void TopggleShooting(bool shoot)
    {
        isShoot = shoot;
    }
}
