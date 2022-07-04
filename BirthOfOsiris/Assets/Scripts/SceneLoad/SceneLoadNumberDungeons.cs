using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadNumberDungeons : MonoBehaviour
{
    [SerializeField]private int _dungeonNumber;
    public int dungeonNumber { get { return _dungeonNumber; } set => _dungeonNumber = value; }
}
