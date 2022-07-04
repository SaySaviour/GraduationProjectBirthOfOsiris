using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Create Key")]
public class Key : ScriptableObject
{
    [SerializeField]private int maxCount;
    public int count;
    public int keyStack=0;
    public GameObject keyObj;
    public GameObject keyDownPos;
    public void Reset()
    {
        count = maxCount-1;
        keyStack = 0;
    }
}
