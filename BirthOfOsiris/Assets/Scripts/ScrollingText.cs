using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScrollingText : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField][TextArea] private string[] itemInfo;
    [SerializeField] private float textSpeed=0.01f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;
    private int currentDisplayingText=0;
    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            ActivateText();
        }
    }
    public void ActivateText()
    {
        StartCoroutine(AnimatedText());
    }
    IEnumerator AnimatedText()
    {
        if (itemInfo.Length>1)
        {
            for (int j = 0; j < itemInfo.Length; j++)
            {
                itemInfoText.text = "";
                for (int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++)
                {
                    itemInfoText.text = itemInfo[currentDisplayingText].Substring(0, i);
                    if (Input.anyKey)
                        break;
                    yield return new WaitForSeconds(textSpeed);
                }
                currentDisplayingText++;
                yield return new WaitForSeconds(5f);
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
            {
                SceneManager.LoadScene("OpenWorld");
            }
        }
        else
        {
            for (int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++)
            {
                itemInfoText.text = itemInfo[currentDisplayingText].Substring(0, i);
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }
}
