using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerDetector : MonoBehaviour
{
    public bool playerDetection { get; private set; }
    public Vector2 directiontoTarget => target.transform.position - detectorOrigin.position;

    [Header("OverlapBox Parameters")]
    [SerializeField] private Transform detectorOrigin;
    public Vector2 detectorSize=Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float dectionDelay = 0.3f;
    public LayerMask detectorLayerMask;

    [Header("Gizmo Parameters")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool gizmosShow = true;

    private GameObject target;
    public GameObject Target { 
        get => target;
        private set 
        { 
            target = value;
            playerDetection = target != null;
        } 
    }
    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }
    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(dectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }
    public void PerformDetection()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
        if (collider != null)
            Target = collider.gameObject;
        else
            Target = null;
    }
    private void OnDrawGizmos()
    {
        if (gizmosShow && detectorOrigin != null)
        {
            Gizmos.color = playerDetection ? gizmoDetectedColor : gizmoIdleColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }
}
