using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuestScreen : MonoBehaviour
{
    [SerializeField] private GameObject questScreen;
    public bool isStopped=false;
    
    public void Continue()
    {
        questScreen.SetActive(false);
        isStopped = false;
    }
    public void Stopped()
    {
        questScreen.SetActive(true);
        isStopped = true;
    }
    

}
