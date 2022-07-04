using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Player Control Settings")]
 public class PlayerControlSettings : ScriptableObject
  {
    
    [Header("Jump And Move")]
    private bool _jumpPressed = false;
    public bool jumpPressed { get =>_jumpPressed; set => _jumpPressed = value; }
    private bool _holdjump = false;
    public bool holdjump { get => _holdjump; set => _holdjump = value; }
    [SerializeField] private float _jumpforce = 350f;
    public float jumpforce { get => _jumpforce; }
    [SerializeField] private float _overlapsize = 0.2f;
    public float overlapsize { get => _overlapsize; }
    [SerializeField] private float _jumpfallvalue = 4f;
    public float jumpfallvalue { get => _jumpfallvalue; }
    [SerializeField] private float _minimumjumpmultiplier = 5f;
    public float minimumjumpmultiplier { get => _minimumjumpmultiplier; }
    [SerializeField] private float _moveSpeed=200f;
    public float moveSpeed { get => _moveSpeed; }
    private float _movehorizontal;
    public float movehorizontal { get => _movehorizontal; set => _movehorizontal = value; }
    private bool _grounded;
    public bool grounded { get => _grounded; set => _grounded=value; }

    [SerializeField] private float _hurtForce;
    public float hurtForce { get => _hurtForce; }
    
    private bool _isHurting = false;
    public bool isHurting { get => _isHurting; set => _isHurting = value; }
}
