using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    float shieldDuration = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, shieldDuration);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1000);
        }
        else if (collision.gameObject.CompareTag("Enemy/Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
