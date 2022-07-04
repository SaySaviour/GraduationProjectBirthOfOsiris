using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerControlSettings _settings;
    [SerializeField] private Transform groundPos;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private PlayerHealth playerhealth;
    [SerializeField] private GameObject attackBall;
    [SerializeField] private Image cooldownImage;
    [SerializeField] private GameObject coolDownGameObject;
    [SerializeField] private TMP_Text textcoolDown;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip[] playerAudioClips;
    [SerializeField]private float cooldown = 3f;
    private bool iscoolDown = false;
    private float CooldownCountdown = 0f;
    void Update()
    {
        JumpInput();
        if (CooldownCountdown < 0f)
        {
            coolDownGameObject.SetActive(false);
            iscoolDown = false;
            textcoolDown.gameObject.SetActive(false);
            cooldownImage.fillAmount = 0f;
            if (Input.GetMouseButton(0))
            {
                PlayerAttack();
                UseAttack();
            }
        }
        else
        {
            CooldownCountdown -= Time.deltaTime;
            textcoolDown.text = Mathf.RoundToInt(CooldownCountdown).ToString();
            cooldownImage.fillAmount = CooldownCountdown / cooldown;
        }
    }
    private bool UseAttack()
    {
        if (iscoolDown)
            return false;
        else
        {
            iscoolDown = true;
            coolDownGameObject.SetActive(true);
            textcoolDown.gameObject.SetActive(true);
            CooldownCountdown = cooldown;
            return true;
        }
    }
    private void Start()
    {
        playerhealth = GetComponent<PlayerHealth>();
        playerAudioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        
        if(_settings.isHurting!=true)
        {
            PlayerMove();
            JumpOrHoldJump();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && playerhealth.GetHealth() > 0)
        {
            PlayerHurt("Enemy");
        }
        else if(playerhealth.GetHealth() <= 0)
        {
            playerAnim.SetTrigger("isDead");
            playerAudioSource.PlayOneShot(playerAudioClips[2]);
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            StartCoroutine(Dead(playerAnim.GetCurrentAnimatorStateInfo(0).length+0.5f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && playerhealth.GetHealth() > 0)
        {
            PlayerHurt("Enemy");
        }
        else if(playerhealth.GetHealth() <= 0)
        {
            playerAnim.SetTrigger("isDead");
            playerAudioSource.PlayOneShot(playerAudioClips[2]);
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());            
            StartCoroutine(Dead(playerAnim.GetCurrentAnimatorStateInfo(0).length+0.5f));
        }
    }
    IEnumerator Dead(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Hurt()
    {
        _settings.isHurting = true;
        playerRB.velocity = Vector2.zero;
        playerAudioSource.PlayOneShot(playerAudioClips[1]);
        if (_settings.movehorizontal > 0)
            playerRB.AddForce(new Vector2(_settings.hurtForce, _settings.hurtForce));
        else
            playerRB.AddForce(new Vector2(-_settings.hurtForce, _settings.hurtForce));
        yield return new WaitForSeconds(0.5f);
        _settings.isHurting = false;
    }
    private void PlayerAttack()
    {
        playerAnim.SetTrigger("isAttackingMagic");
        StartCoroutine(DelayShoot(playerAnim.GetCurrentAnimatorStateInfo(0).length));

    }
    IEnumerator DelayShoot(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(attackBall, transform.position, transform.rotation);
    }
    private void PlayerHurt(string enemy)
    {
        playerAnim.SetTrigger("isHurting");
        playerhealth.UpdateHealth(GameObject.FindGameObjectWithTag(enemy).GetComponent<EnemyAttack>().GetDamage());
        StartCoroutine("Hurt");
    }
    private void PlayerMove()
    {
        _settings.movehorizontal = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(_settings.movehorizontal *_settings.moveSpeed * Time.fixedDeltaTime,playerRB.velocity.y);
        PlayerFlip();
        playerAnim.SetFloat("walkSpeed",Mathf.Abs(playerRB.velocity.x));
    }
    private void JumpOrHoldJump()
    {
        if (_settings.jumpPressed)
        {
            PlayerJump();
        }
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += new Vector2(0, Physics.gravity.y * (_settings.jumpfallvalue - 1) * Time.deltaTime);
        }
        if (playerRB.velocity.y > 0 && !_settings.holdjump)
        {
            playerRB.velocity += new Vector2(0, Physics.gravity.y * (_settings.minimumjumpmultiplier - 1) * Time.deltaTime);
        }
    }
    private void PlayerJump()
    {
       _settings.grounded = false;
        if(!playerAudioSource.isPlaying)
            playerAudioSource.PlayOneShot(playerAudioClips[0]);
       playerRB.AddForce(new Vector2(0f, _settings.jumpforce *Time.deltaTime),ForceMode2D.Impulse);
       _settings.jumpPressed = false;
    }
    
    private void JumpInput()
    {
        bool wasGrounded =_settings.grounded;
        _settings.grounded = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundPos.position, new Vector2(transform.localScale.x, _settings.overlapsize), 0, LayerMask.GetMask("Ground"));

        playerAnim.SetBool("isGrounded", false);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _settings.grounded = true;
                playerAnim.SetBool("isGrounded", true);
                break;
            }
        }
        if (Input.GetButtonDown("Jump")&& _settings.grounded)
        {
            _settings.jumpPressed = true;
        }

        else if (Input.GetButton("Jump"))
        {
            _settings.holdjump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            _settings.holdjump = false;
        }
        
    }
    private void PlayerFlip()
    {
        if (_settings.movehorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        else if (_settings.movehorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}
