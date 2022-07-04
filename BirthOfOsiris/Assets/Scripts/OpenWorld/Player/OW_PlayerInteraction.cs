using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OW_PlayerInteraction : MonoBehaviour
{
    [SerializeField] private MenuQuestScreen questScreen;
    [SerializeField] private GameObject minimap;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if (questScreen.isStopped)
            {
                questScreen.Continue();
                minimap.SetActive(true);
            }
        }
        if(Input.GetKey(KeyCode.M))
        {
            minimap.SetActive(!minimap.activeSelf);
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && !questScreen.isStopped)
        {
            if (Input.GetKey(KeyCode.E))
            {
                questScreen.Stopped();
                minimap.SetActive(false);
            }
        }
           
    }
}
