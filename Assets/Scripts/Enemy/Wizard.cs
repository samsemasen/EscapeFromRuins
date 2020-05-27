using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    Transform player;

    public bool isFlipped = true;

	//public float shootRate = 20f;
	float nextShoot = 0;

	public Transform firePoint;
	public GameObject firePrefab;

	public Animator WizardAnim;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	    
	}


	void Update()
    {
		FaceThePlayer();

		if (Time.time > nextShoot) {
			int randShootRate = Random.Range(5, 15);
			nextShoot = Time.time + randShootRate;
			Shoot();
			
		}

		}

	void FaceThePlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped) {
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		} else if (transform.position.x < player.position.x && !isFlipped) {
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	void Shoot()
	{
		WizardAnim.SetTrigger("shoot");

		StartCoroutine(waiter());

		
	}

	IEnumerator waiter()
	{

		//Wait for 0.7 seconds
		yield return new WaitForSecondsRealtime(0.7f);

		Instantiate(firePrefab, firePoint.position, firePoint.rotation);

	}
}
