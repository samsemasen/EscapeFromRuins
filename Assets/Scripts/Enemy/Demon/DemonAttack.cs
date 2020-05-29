using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public Animator anim;
    
    
    public float attackRange = 5f;
    float nextShoot = 0;

    public Transform firePos;
    public GameObject demonFire;


    void Update()
    {
        if (Vector2.Distance(player.position, rb.position) <= attackRange && (Time.time > nextShoot)) {
            int randShootRate = Random.Range(5, 7);
            nextShoot = Time.time + randShootRate;
            anim.SetTrigger("Attack");
            //DemonFire();
        }
    }

   
    public void DemonShootFire() //  this function would be called from animator state machine when demon in attack state
    {
        if (rb.transform.localScale.x < 0) { // looking left
            Instantiate(demonFire, firePos.position, firePos.rotation * Quaternion.Euler(0f, 180f, 0f));
        } else if (rb.transform.localScale.x > 0) { // looking right
            Instantiate(demonFire, firePos.position, firePos.rotation);
        }
    }

    

    /*
   void DemonFire()
   {
       anim.SetTrigger("Attack");
      // StartCoroutine(waiter());



   }
   */

    /*

    IEnumerator waiter()
    {

        //Wait for 0.7 seconds
        yield return new WaitForSecondsRealtime(0.7f);

        //Instantiate(demonFire, firePos.position, firePos.rotation);

        if (rb.transform.localScale.x < 0) { // looking left
            Instantiate(demonFire, firePos.position, firePos.rotation * Quaternion.Euler(0f, 180f, 0f));
        } else if (rb.transform.localScale.x > 0) { // looking right
            Instantiate(demonFire, firePos.position, firePos.rotation );
        }

    }
    */
}
