using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadAction : MonoBehaviour
{
    [SerializeField]private OW_PlayerMovementSettings player_settings;
    [SerializeField]private SceneLoadNumberDungeons slnumberDungeons;
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dungeon"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                player_settings.openWordLastPosition = transform.position;
                slnumberDungeons = collision.gameObject.GetComponentInParent<SceneLoadNumberDungeons>();
                SceneManager.LoadScene(slnumberDungeons.dungeonNumber+1);
            }

        }
        if (collision.gameObject.CompareTag("Door"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("OpenWorld");
            }
        }
          
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded; 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == SceneManager.GetSceneByName("OpenWorld"))
            transform.position = player_settings.openWordLastPosition+new Vector3(5,0,0);
    }
}
