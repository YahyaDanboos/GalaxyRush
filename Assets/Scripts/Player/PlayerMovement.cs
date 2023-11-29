using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D playerRigidbody;

    [Header("Movement Settings")]
    public float movementSpeed = 5f;

    // Stored Values
    Vector2 movementDirection;
    Vector2 screenBounds;

    void Start()
    {
        // Calculate the screen bounds
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

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
        // Apply movement
        Vector2 newPosition = playerRigidbody.position + movementDirection.normalized * movementSpeed * Time.fixedDeltaTime;

        // Clamp the new position within the screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        // Set the clamped position
        playerRigidbody.position = newPosition;
    }
}
