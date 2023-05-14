// Altın sikkeleri toplayınca yok olmasını ve skoru güncelleyen script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public int score = 0;
    [SerializeField] Text coinsText;
    [SerializeField] AudioSource collectSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score++;
            coinsText.text = "Skor : " + score;
            collectSound.Play();

        }
    }
}
