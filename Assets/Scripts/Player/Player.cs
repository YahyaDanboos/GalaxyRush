using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Component References")]
    public Health playerHealth;

    // Called when something damages the player
    public void TakeDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
    }

    // Called when the player is destroyed
    void Defeated()
    {
        Destroy(gameObject);
    }
}
