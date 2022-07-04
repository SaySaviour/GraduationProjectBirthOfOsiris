using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton1Controller : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float distance;
    private bool movingright = true;
    [SerializeField]private Transform groudDetection;
    [SerializeField]private Animator enemyAnimator;
    [SerializeField]private Rigidbody2D enemyRigidbody;
    public AIPlayerDetector playerDetector;
    [SerializeField] private GameObject arrow;
    [SerializeField]private float fireRate;
    [SerializeField] private float nextFire;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Key key;
    [SerializeField] private AudioSource enemyAudioSource;
    private bool isHurting=false;
    private float hurtForce;
    public bool isDead = false;
    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        enemyHealth = GetComponent<EnemyHealth>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        enemyAudioSource=GetComponent<AudioSource>();
        key.Reset();
    }
    void Update()
    {
        if (isHurting != true && isDead!=true)
        {
            EnemyWalk();
        }

    }
    void enemyFlip()
    {
        RaycastHit2D groundinfo = Physics2D.Raycast(groudDetection.position, Vector2.down, distance);
        if (groundinfo.collider==false)
        {
            if(movingright==true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }
    }
    private void EnemyAttack()
    {
        transform.Translate(Vector2.zero);
        enemyAnimator.SetBool("isAttacking", true);
        StartCoroutine(DelayShoot(enemyAnimator.GetCurrentAnimatorStateInfo(0).length));
    }
    IEnumerator DelayShoot(float _delay=0)
    {
        yield return new WaitForSeconds(_delay);
        if (Time.time > nextFire)
        {
            Instantiate(arrow, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttackBall") && enemyHealth.GetHealth() > 0)
        {
            EnemyHurt("Player");
        }
        else if(collision.gameObject.CompareTag("RestartGround"))
        {
            EnemyDead();
        }
        else if (enemyHealth.GetHealth() <= 0)
        {
            EnemyDead();
        }
    }
    private void EnemyDead()
    {
        enemyAnimator.SetTrigger("isDead");
        enemyAudioSource.Play();
        isDead = true;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(enemyRigidbody);
        if (key.count <= 0)
        {
            Instantiate(key.keyObj, key.keyDownPos.transform.position, key.keyDownPos.transform.rotation);
        }
        else
            key.count--;
        StartCoroutine(Dead(enemyAnimator.GetCurrentAnimatorStateInfo(0).length + 0.5f));
    }
    IEnumerator Dead(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject,delay);
    }
    private void EnemyHurt(string player)
    {
        enemyAnimator.SetTrigger("isHurting");
        enemyHealth.UpdateHealth(GameObject.Find(player).GetComponent<PlayerAttack>().getDamage());
        StartCoroutine("Hurt");
    }
    IEnumerator Hurt()
    {
        isHurting = true;
        enemyRigidbody.velocity = Vector2.zero;
        if (movingright)
            enemyRigidbody.AddForce(new Vector2(hurtForce, hurtForce));
        else
            enemyRigidbody.AddForce(new Vector2(-hurtForce,hurtForce));
        yield return new WaitForSeconds(0.5f);
        isHurting = false;
    }
    private void EnemyWalk()
    {
        if (playerDetector.playerDetection)
        {
            EnemyAttack();
        }
        else
        {
            enemyAnimator.SetBool("isAttacking", false);
            enemyAnimator.SetBool("isWalking", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            enemyFlip();
        }
        
    }
}
