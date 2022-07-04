using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArrow : MonoBehaviour
{
    [SerializeField]public Transform[] target;
    [SerializeField] private float buffer;
    [SerializeField]private float maxDistance;
    int dungeonNumber;
    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            dungeonNumber = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            dungeonNumber = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            dungeonNumber = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            dungeonNumber = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            dungeonNumber = 4;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            dungeonNumber = 5;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            dungeonNumber = 6;
        }
        UpdateArrowRotation(dungeonNumber);
    }
    private void UpdateArrowRotation(int dungeonNumber)
    {
        Vector2 difference = transform.position - target[dungeonNumber].position;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + buffer);
    }
}
