using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject destroyedVFX;

    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    public event Action characterDefeated;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
    }

    // Damage the character
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Defeated();
    }

    void Defeated()
    {
        characterDefeated?.Invoke();
        Instantiate(destroyedVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
