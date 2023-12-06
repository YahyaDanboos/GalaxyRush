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
    int currentHealth;

    bool isInvulnerable = false;

    public event Action characterDefeated;
    public event Action addLife;

    void Start()
    {
        currentHealth = maxHealth;

        if (gameObject.tag == "Player")
            StartCoroutine(InvulnerabilityPeriod());
    }

    IEnumerator InvulnerabilityPeriod()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(3f); 
        isInvulnerable = false;
    }

    // Damage the character
    public void TakeDamage(int damage)
    {
        if (isInvulnerable == false)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
                Defeated();
        }
    }

    void Defeated()
    {
        Instantiate(destroyedVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        characterDefeated?.Invoke();
    }

    public void AddLife()
    {
        addLife?.Invoke();
    }
}
