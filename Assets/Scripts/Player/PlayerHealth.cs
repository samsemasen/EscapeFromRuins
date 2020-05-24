﻿using System.Collections;
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
		playerAnim.SetTrigger("hurt");

		if (health <= 0) {
			Die();
		}
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
}
