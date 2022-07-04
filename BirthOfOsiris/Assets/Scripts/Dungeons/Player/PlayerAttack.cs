using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float playerDamage;
    private void Start()
    {
        playerDamage = -playerDamage;
    }
    public void UpdateDamage(float newDamage)
    {
        playerDamage += newDamage;
    }
    public float getDamage()
    {
        return playerDamage;
    }
}
