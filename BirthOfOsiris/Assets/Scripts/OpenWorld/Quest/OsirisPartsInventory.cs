using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Create Osiris Part Inventory")]
public class OsirisPartsInventory : ScriptableObject
{
    public List<Sprite> osirisParts;

    public void Reset()
    {
        osirisParts = new List<Sprite>(0);
    }
}
