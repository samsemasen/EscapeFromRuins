using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation 

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die()
    {
        // die animation
        animator.SetBool("isDead", true);

        Destroy(gameObject, 0.5f);
   
    }
}
