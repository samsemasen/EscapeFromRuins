using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnim;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public LayerMask enemyLayer;


   

    private void Update()
    {
        if(timeBtwAttack <= 0) {
            //then you can attack
            if (Input.GetKey(KeyCode.Alpha1)) {
                playerAnim.SetTrigger("Punch");
                Attack();

            } else if (Input.GetKey(KeyCode.Alpha2)) {

                if (Input.GetKey(KeyCode.DownArrow) && playerAnim.GetBool("isGrounded")) {
                    playerAnim.SetBool("isCrouching", false);
                    playerAnim.SetTrigger("CrouchKick");
                    Attack();

                } else if(playerAnim.GetBool("isGrounded")== false) {
                    playerAnim.SetTrigger("FlyingKick");
                    Attack();

                } else {
                    playerAnim.SetTrigger("Kick");
                    Attack();
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void Attack()
    {
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Damage them
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    // to draw the attack range so we can change it as we like
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
