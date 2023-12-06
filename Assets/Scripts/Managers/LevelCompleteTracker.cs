using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTracker : MonoBehaviour
{
    [Header("Component References")]
    public GameManager gameManager;

    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var enemy in FindObjectsOfType<EnemyCombat>())
        {
            enemies.Add(enemy.gameObject);
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.characterDefeated += () => EnemyDefeated(enemy.gameObject);
            }
        }
    }

    public void EnemyDefeated(GameObject enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0)
        {
            gameManager.GameWin();
        }
    }
}
