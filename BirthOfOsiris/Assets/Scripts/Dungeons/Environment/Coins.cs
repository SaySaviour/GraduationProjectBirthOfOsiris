using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CoinPointer coin;
    [SerializeField] private AudioClip coinSource;
    private void Start()
    {
        text.text= "TOPLAM KUTSAL BÖCEK PUANI: " + coin.maxPoint;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSource,transform.position);
            if (gameObject.tag == "RedCoin")
                coin.redCoin = true;
            else
                coin.redCoin = false;
            
            if (!coin.redCoin)
                coin.maxPoint += coin.coinPoint;
            else
                coin.maxPoint += coin.redCoinPoint;
            text.text = "TOPLAM KUTSAL BÖCEK PUANI: " + coin.maxPoint;
            Destroy(gameObject);
        }
    }
}
