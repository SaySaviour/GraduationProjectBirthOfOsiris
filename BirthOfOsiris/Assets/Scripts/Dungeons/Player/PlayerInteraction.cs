using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]private Key key;
    [SerializeField] private GameObject osirisPart;
    public OsirisPartsInventory osirisPartsInventory;
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField] private AudioClip getKeyClip;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                key.keyStack++;
                text.text =""+key.keyStack;
                AudioSource.PlayClipAtPoint(getKeyClip,transform.position);
                Destroy(collision.gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("TombStone"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Animator anim = collision.gameObject.GetComponent<Animator>();
                if (key.keyStack > 0)
                {
                    key.keyStack=0;
                    text.text = "" + key.keyStack;
                    anim.SetTrigger("isOpen");
                    Instantiate(osirisPart, collision.gameObject.transform.position, Quaternion.identity);
                    Destroy(collision.gameObject.GetComponent<CapsuleCollider2D>());
                }
                
            }
        }
        else if (collision.gameObject.CompareTag("OsirisParts"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!osirisPartsInventory.osirisParts.Contains(collision.gameObject.GetComponent<SpriteRenderer>().sprite))
                    osirisPartsInventory.osirisParts.Add(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
                Destroy(collision.gameObject);
            }
        }
    }

}
