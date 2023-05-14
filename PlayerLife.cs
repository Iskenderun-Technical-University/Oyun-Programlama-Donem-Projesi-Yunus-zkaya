// Oyuncunun ölme ve hayatta kalma durumlarını kontrol eden script; buna göre öldüğünden yeniden başlar.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource deadSound;
    private void Update()
    {
        if (transform.position.y < -0.75f && !dead)
        {
            Die();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic= false;
        GetComponent<PlayerController>().enabled = false;
        Invoke(nameof(ReloadLevel),.7f);
        dead= true;
        deadSound.Play();
    }     
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
