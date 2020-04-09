using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
 
    public Animator playerAnim;
   

    private void Update()
    {
        if(timeBtwAttack <= 0) {
            //then you can attack
            if (Input.GetKey(KeyCode.Alpha1)) {
                playerAnim.SetTrigger("Punch");

            } else if (Input.GetKey(KeyCode.Alpha2)) {

                if (Input.GetKey(KeyCode.DownArrow) && playerAnim.GetBool("isGrounded")) {
                    playerAnim.SetBool("isCrouching", false);
                    playerAnim.SetTrigger("CrouchKick");

                } else if(playerAnim.GetBool("isGrounded")== false) {
                    playerAnim.SetTrigger("FlyingKick");

                } else {
                    playerAnim.SetTrigger("Kick");
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }


}
