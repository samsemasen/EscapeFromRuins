using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int health = 100;
	public int numberOfHearts =10 ;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	public Animator playerAnim;

	private void Update()
	{
		for (int i = 0; i < hearts.Length ; i++) {
			
			if(i < numberOfHearts) {
				hearts[i].sprite = fullHeart;
			} else {
				hearts[i].sprite = emptyHeart;
			}

		}
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
		numberOfHearts -= 1;

		//hurt
		//playerAnim.SetTrigger("hurt");

		if (health <= 0) {
			Die();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("KillPlayer")) {
			playerAnim.SetTrigger("hurt");
			TakeDamage(100);
		}

		if (collision.CompareTag("Enemy")) {
			playerAnim.SetTrigger("hurt");
			TakeDamage(10);
		}
	}

		void Die()
	{
		FindObjectOfType<GameManager>().EndGame();
	}
	
}
