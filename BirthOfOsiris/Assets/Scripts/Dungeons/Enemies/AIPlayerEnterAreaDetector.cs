using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerEnterAreaDetector : MonoBehaviour
{
    public bool playerinArea { get; private set; }
    public Transform player { get; private set; }
    public string detectionTag="Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == detectionTag)
        {
            playerinArea = true;
            player =collision.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == detectionTag)
        {
            playerinArea = false;
            player = null;
        }
    }
}
