using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject storyCanvas;
    [SerializeField] private GameObject settingsCanvas;
    public void MainMenuOpen()
    {
        mainMenuCanvas.SetActive(true);
    }
    public void SettingsMenuOpen()
    {
        settingsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }
    public void SettingsMenuClose()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void StoryCanvasOpen()
    {
        storyCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
