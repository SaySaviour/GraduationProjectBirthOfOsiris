using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float enemyHealth = 0f;
    [SerializeField] private float maxEnemyHealth = 100f;
    private void Start()
    {
        enemyHealth = maxEnemyHealth;
    }
    public void UpdateHealth(float mod)
    {
        enemyHealth += mod;
        if (enemyHealth > maxEnemyHealth)
        {
            enemyHealth = maxEnemyHealth;
        }
        else if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }
    public float GetHealth()
    {
        return enemyHealth;
    }
}
