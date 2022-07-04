using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]private float enemyDamage;
    private void Start()
    {
        enemyDamage = -enemyDamage;
    }
    public void UpdateDamage(float newdamage)
    {
        enemyDamage += newdamage;
    }
    public float GetDamage()
    {
        return enemyDamage;
    }
}
