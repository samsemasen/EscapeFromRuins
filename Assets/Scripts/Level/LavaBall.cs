using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{
    //direction
    public int goingUp;

    public float speed = 4;
    public Rigidbody2D rb;

    public int damage = 10;

   

    void Start()
    {
        goingUp = 1;
        Move();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //change direction when colide with tag name firepoints
        if (collision.CompareTag("FirePoints")) {
            ChangeDirection();
        }

        else if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerHealth>().playerAnim.SetTrigger("hurt");
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            goingUp = -1;
        }
    }


    void Move()
    {
        rb.velocity = transform.up * goingUp * speed;
    }

    void ChangeDirection()
    {
        goingUp = -1 * goingUp;
    }
}
