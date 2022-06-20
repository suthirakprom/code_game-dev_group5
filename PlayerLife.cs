using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject fallDetector;
    public GameObject[] hearts;
    public int life = 4;
    private bool dead;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap")) {
            life -= 1;
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag =="FallDetector") {
            Die();
        }
        if (collision.tag =="enemy") {
            Die();
        }
    }


    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
