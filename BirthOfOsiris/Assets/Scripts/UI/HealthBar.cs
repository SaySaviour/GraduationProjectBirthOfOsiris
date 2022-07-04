using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;
    [SerializeField] private PlayerHealth playerHealth; 

    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        
    }
    private void Update()
    {
        if (playerHealth.GetHealth() <= 30)
        {
            barImage.color = Color.red;
        }
        SetSize(playerHealth.GetHealth() / 100f);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
