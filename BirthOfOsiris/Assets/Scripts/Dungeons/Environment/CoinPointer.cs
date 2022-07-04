using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Create Coin")]
public class CoinPointer : ScriptableObject
{
    public int coinPoint;
    public int redCoinPoint;
    public int maxPoint;
    public int coinValue;
    public bool redCoin;

    public void Reset()
    {
        maxPoint = 0;
    }

}
