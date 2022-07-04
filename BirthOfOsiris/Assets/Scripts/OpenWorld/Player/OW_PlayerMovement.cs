using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class OW_PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private OW_PlayerMovementSettings _OWsettings;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip[] playerAudioClips;
    int speedcount = 0;
    void Start()
    {
        _OWsettings.Reset();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        _OWsettings.movehorizontal = Input.GetAxisRaw("Horizontal");
        _OWsettings.moveVertical=Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift)&&speedcount==0)
        {
            _OWsettings.moveSpeed =_OWsettings.moveSpeed+300;
            speedcount=1;
        }
        else if(Input.GetKey(KeyCode.LeftControl) && speedcount != 0)
        {
            _OWsettings.moveSpeed = _OWsettings.moveSpeed -300;
            speedcount = 0;
        }
        playerRB.velocity = new Vector2(_OWsettings.movehorizontal * _OWsettings.moveSpeed * Time.fixedDeltaTime, _OWsettings.moveVertical *_OWsettings.moveSpeed * Time.fixedDeltaTime);
        PlayerFlip();
        if(_OWsettings.movehorizontal!=0 || _OWsettings.moveVertical!=0)
        {
            playerAnim.SetBool("isWalking",true);
            if(!playerAudioSource.isPlaying)
                playerAudioSource.PlayOneShot(playerAudioClips[0]);
        }
        else
        {
            playerAnim.SetBool("isWalking",false);
        }
    }
     private void PlayerFlip()
    {
        if (_OWsettings.movehorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        else if (_OWsettings.movehorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}
