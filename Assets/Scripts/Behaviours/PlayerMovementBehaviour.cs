using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D playerRigidbody;

    [Header("Movement Settings")]
    public float movementSpeed = 5f;

    //Stored Values
    private Vector2 movementDirection;

    void FixedUpdate()
    {
        MoveThePlayer();
    }

    public void UpdateMovementData(Vector2 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    void MoveThePlayer()
    {
        playerRigidbody.velocity = movementDirection * movementSpeed * Time.fixedDeltaTime;
    }
}
