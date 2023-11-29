using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D enemyRigidbody;

    [Header("Movement Settings")]
    public float movementSpeed = 5f;
    public bool isSinMovement = false;
    public float waveAmplitude = 0.5f;

    //Stored Values
    float sinCenterX;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        Vector2 newPosition = transform.position;
        newPosition.y -= movementSpeed * Time.fixedDeltaTime;

        if (isSinMovement)
        {
            float sinOffset = Mathf.Sin(newPosition.y) * waveAmplitude;
            newPosition.x = sinCenterX + sinOffset;
        }

        enemyRigidbody.MovePosition(newPosition);

        // destroy the enemy if it is below the bottom of the screen
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.y < -0.2f)
        {
            Destroy(gameObject);
        }
    }
}
