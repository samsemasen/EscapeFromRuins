using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonHealth : MonoBehaviour
{
    //public Animator animator;

    public int maxHealth = 100;
    //int currentHealth;
    int health;

    public int numberOfHearts = 10;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    void Start()
    {
        health = maxHealth;
        
    }

    private void Update()
    {
        health = GetComponent<Enemy>().currentHealth;
        numberOfHearts = health / 40;

        for (int i = 0; i < hearts.Length; i++) {

            if (i < numberOfHearts) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

        }
    }
    
}
