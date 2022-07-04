using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterMenuScreenControl : MonoBehaviour
{
    [SerializeField] private GameObject characterInventoryMenu;
    [SerializeField] private GameObject characterUIMenu;
    [SerializeField] private GameObject stoppedMenu;
    [SerializeField] private GameObject howtoPlayMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject minimap;
    [SerializeField] private GameObject osirisPartControlText;
    [SerializeField] private Image[] osirisPartsimages;
    [SerializeField] private Image[] owOsirisPartImages;
    [SerializeField] private TextMeshProUGUI[] ositisPartText;
    [SerializeField] private OsirisPartsInventory osirisPartsInventory;
    [SerializeField] private OW_PlayerMovementSettings playerMovementSettings;
    [SerializeField] private CoinPointer coinPointer;
    private bool characterInventoryisOpen = false;
    private bool stoppedMenuisOpen = false;
    private bool howtoPlayMenuisOpen = false;
    private bool settingsMenuOpen = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!stoppedMenuisOpen)
                MenuStopped();
        }   
       else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!stoppedMenuisOpen)
                StoppedMenuOpen();
            if (settingsMenuOpen)
                SettingMenuClose();
            if (howtoPlayMenuisOpen)
                hawtoPlayMenuClose();
            MenuContinue();
        }
    }
    public void ComplateStory()
    {
        if(osirisPartsInventory.osirisParts.Count<5)
        {
            osirisPartControlText.SetActive(true);
            for (int i = 0; i < osirisPartsInventory.osirisParts.Count; i++)
            {
                owOsirisPartImages[i].sprite = osirisPartsInventory.osirisParts[i];
            }
            StartCoroutine(DelayTextDontShow());
        }
        else
        {
            for (int i = 0; i < osirisPartsInventory.osirisParts.Count; i++)
            {
                owOsirisPartImages[i].sprite = osirisPartsInventory.osirisParts[i];
            }
            SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator DelayTextDontShow()
    {
        yield return new WaitForSeconds(3f);
        osirisPartControlText.SetActive(false);
    }
    public void InventoryOpen()
    {
        if(osirisPartsInventory.osirisParts!=null)
        {
            for (int i = 0; i < osirisPartsInventory.osirisParts.Count; i++)
            {
                osirisPartsimages[i].sprite = osirisPartsInventory.osirisParts[i];
                ositisPartText[i].text = osirisPartsInventory.osirisParts[i].name;
            }
        }
    }
    public void StoppedMenuOpen()
    {
        if(!stoppedMenuisOpen)
        {
            stoppedMenuisOpen = true;
            stoppedMenu.SetActive(true);
            if(minimap!=null)
                minimap.SetActive(false);
            if (characterUIMenu != null)
                characterUIMenu.SetActive(false);
            Time.timeScale = 0f;
        }
        
    }
    public void StoppedMenuClose()
    {
        if(stoppedMenuisOpen)
        {
            stoppedMenu.SetActive(false);
            stoppedMenuisOpen = false;
            if (minimap != null)
                minimap.SetActive(true);
            if(characterUIMenu!=null)
                characterUIMenu.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    public void hawtoPlayMenuClose()
    {
        howtoPlayMenuisOpen = false;
        howtoPlayMenu.SetActive(false);
        stoppedMenu.SetActive(true);
    }
    public void hawtoPlayMenuOpen()
    {
        howtoPlayMenuisOpen = true;
        howtoPlayMenu.SetActive(true);
        stoppedMenu.SetActive(false);
    }
    public void SettingMenuOpen()
    {
        settingsMenuOpen = true;
        stoppedMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void SettingMenuClose()
    {
        settingsMenuOpen = false;
        stoppedMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void NewGameButton()
    {
        osirisPartsInventory.Reset();
        coinPointer.Reset();
        playerMovementSettings.Reset();
        SceneManager.LoadScene("OpenWorld");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void MenuContinue()
    {
        if (characterInventoryisOpen)
        {
            characterInventoryMenu.SetActive(false);
            if(characterUIMenu!=null)
                characterUIMenu.SetActive(true);
            StoppedMenuOpen();
            characterInventoryisOpen = false;
            Time.timeScale = 1f;
        }
    }
    public void MenuStopped()
    {
        
        if(!characterInventoryisOpen)
        {
            InventoryOpen();
            characterInventoryMenu.SetActive(true);
            if (characterUIMenu != null)
                characterUIMenu.SetActive(false);
            characterInventoryisOpen = true;
            Time.timeScale = 0f;
        }
    }
}
