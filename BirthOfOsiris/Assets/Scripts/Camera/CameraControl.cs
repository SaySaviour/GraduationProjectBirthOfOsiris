using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Range(1,10)][SerializeField] private float smoothsSpeed=0.125f;
    [SerializeField] private Vector3 offset;
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothsSpeed*Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
