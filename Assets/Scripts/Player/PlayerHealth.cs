using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int health = 100;
	//public GameObject deathEffect;

	public Animator playerAnim;

	public void TakeDamage(int damage)
	{
		health -= damage;

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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
}
