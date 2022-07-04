using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPosition : MonoBehaviour
{
    [SerializeField] private Transform restartPosition;
    private void OnTriggerEnter2D(Collider2D Ground)
    {
        if (Ground.gameObject.CompareTag("RestartGround"))
        {
            transform.position = restartPosition.position;
        }
    }
}
