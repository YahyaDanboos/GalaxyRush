using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D powerUpRigidbody;

    float speed = 2;

    public enum PowerUpTypes
    {
        ExtraLife,
        Shield,
        MultipleShot
    }

    public PowerUpTypes powerUp;

    // Update is called once per frame
    void FixedUpdate()
    {
        powerUpRigidbody.position = powerUpRigidbody.position + Vector2.down * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (powerUp)
            {
                case PowerUpTypes.ExtraLife:
                    collision.gameObject.GetComponent<Health>().AddLife();
                    break;
                case PowerUpTypes.MultipleShot:
                    break;
                case PowerUpTypes.Shield:
                    break;
            }

            Destroy(gameObject);                
        }
    }
}
