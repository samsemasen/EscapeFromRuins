using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
   
    public float speed = 20f;
    public Rigidbody2D rb;

    public int damage = 10;

    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerHealth>().playerAnim.SetTrigger("hurt");
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);         
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Wall")) { 
           Destroy(gameObject);
        }      
    }

}
