using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D bulletRigidbody;

    [Header("Movement Settings")]
    public float speed = 2f;

    [Header("Combat Settings")]
    public int attackPower = 10;

    // Lifetime of the bullet in seconds
    float lifetime = 5f;

    // The tag of the target that the bullet is trying to hit
    string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        // Automatically destroy the bullet after its lifetime
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the direction based on the bullet's rotation
        Vector2 direction = transform.up;
        bulletRigidbody.velocity = direction.normalized * speed;

        // destroy the bullet if it is outside of the screen
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.y < 0f || viewportPosition.y > 1f)
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletTarget(bool isPlayer, int newAttackPower)
    {
        if (isPlayer)
            targetTag = "Enemy";
        else
            targetTag = "Player";

        attackPower = newAttackPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(attackPower);

            Destroy(gameObject);
        }
    }
}
