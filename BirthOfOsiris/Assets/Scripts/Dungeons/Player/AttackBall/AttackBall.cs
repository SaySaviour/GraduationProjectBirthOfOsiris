using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRb;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Animator ballAnim;
    [SerializeField] private float bulletSpeed = 50;
    [SerializeField]private Vector2 lookDirection;
    [SerializeField] private AudioSource ballAudioSource;
    [SerializeField] private AudioClip[] ballClips;
    float lookAngle;
    private void Start()
    {
        ballAnim = GetComponent<Animator>();
        ballRb = GetComponent<Rigidbody2D>();
        ballAudioSource = GetComponent<AudioSource>();
        if (!ballAudioSource.isPlaying)
            ballAudioSource.PlayOneShot(ballClips[0]);
        firePoint = GameObject.Find("Player").transform.GetChild(1);
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle-90f);
        transform.rotation = Quaternion.Euler(0, 0, lookAngle-90f);
        transform.position = firePoint.position;
        ballRb.velocity = firePoint.up * bulletSpeed;
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ballRb.velocity = Vector2.zero;
            ballAnim.SetBool("isExplotion", true);
            if (!ballAudioSource.isPlaying)
                ballAudioSource.PlayOneShot(ballClips[1]);
            StartCoroutine(DestroyBall(ballAnim.GetCurrentAnimatorStateInfo(0).length));
        }
    }
    IEnumerator DestroyBall(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject, 0.1f);
    }
}
