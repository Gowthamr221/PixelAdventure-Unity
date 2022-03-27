using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAlive : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator DeathAnimator;
    [SerializeField] private AudioSource DeathSound;
    private void Start()
    {
        DeathAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) {
            Die();
            Debug.Log("you hit the spike");
            DeathSound.Play();
            rb.bodyType=RigidbodyType2D.Static;
            
        }
    }

    private void Die() {
        DeathAnimator.SetTrigger("death");
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
