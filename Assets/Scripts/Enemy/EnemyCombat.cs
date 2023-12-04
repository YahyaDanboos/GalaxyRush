using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{   
    [Header("Component References")]
    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    Transform player;

    [Header("Combat Settings")]
    public int attackPower;
    public bool isShootingType;

    // Random Shooting Interval time
    public float minShootInterval = 1.0f;
    public float maxShootInterval = 3.0f;

    bool canShoot = true;
    float nextShootTime;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial time for the next shot
        nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Only shoot after entering the screen
        if (viewportPosition.y < 1f)
        {
            if (isShootingType && canShoot && Time.time >= nextShootTime)
            {
                Shoot();

                // Generate a new random interval for the next shot
                nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
            }
        }        
    }

    void GetPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Shoot Bullet
    void Shoot()
    {
        // Get the player reference
        GetPlayer();

        if (player != null)
        {
            // Calculate the direction vector from the enemy to the player
            Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;

            // Calculate the rotation to face the player
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
            bullet.SetBulletTarget(false, attackPower);
        }
    }

    // You can call this method to enable or disable shooting (e.g., when the enemy is destroyed)
    public void SetCanShoot(bool canShoot)
    {
        this.canShoot = canShoot;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(attackPower);
        }
    }
}
