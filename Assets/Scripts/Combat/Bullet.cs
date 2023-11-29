using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D bulletRigidbody;

    [Header("Movement Settings")]
    public Vector2 direction = new Vector2(0,1);
    public float speed = 2f;

    [Header("Combat Settings")]
    public int attackPower = 10;

    // Lifetime of the bullet in seconds
    private float lifetime = 5f;

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
        bulletRigidbody.velocity = direction.normalized * speed;
    }

    public void SetBulletTarget(bool isPlayer)
    {
        if (isPlayer)
            targetTag = "Enemy";
        else
            targetTag = "Player";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(attackPower);
        }
    }
}
