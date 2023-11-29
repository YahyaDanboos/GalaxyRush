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

    // Lifetime of the bullet in seconds
    private float lifetime = 5f;

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
}
