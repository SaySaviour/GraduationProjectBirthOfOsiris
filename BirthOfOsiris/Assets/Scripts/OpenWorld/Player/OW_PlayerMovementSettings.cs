using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Player OW Control Settings")]
public class OW_PlayerMovementSettings : ScriptableObject
{
   private float _movehorizontal;
    public float movehorizontal { get => _movehorizontal; set => _movehorizontal = value; }
    private float _moveVertical;
    public float moveVertical { get => _moveVertical; set => _moveVertical = value; }
    [SerializeField] private float _moveSpeed=200f;
    public float moveSpeed { get => _moveSpeed; set =>_moveSpeed= value; }
    [SerializeField]private Vector3 _openWordLastPosition =Vector3.zero;
    public Vector3 openWordLastPosition { get => _openWordLastPosition; set => _openWordLastPosition = value; }


    public void Reset()
    {
        moveSpeed = 200f;
        openWordLastPosition = Vector3.zero;
    }
}
