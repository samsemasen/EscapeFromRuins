using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFire : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 10;
    // GameObject player;

    public float attackRange = 3f;
    public LayerMask attackMask;

    /*

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("demonfire collide with player");
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerHealth>().playerAnim.SetTrigger("hurt");
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        } 
    }
    */

    public void Hurt()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(rb.transform.position, attackRange, attackMask);
        if(colInfo != null) { // collide with player
            colInfo.GetComponent<PlayerHealth>().playerAnim.SetTrigger("hurt");
            colInfo.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    public void DemonDestroy()
    {
        Destroy(gameObject);
    }

    // to draw the attack range so we can change it as we like
    private void OnDrawGizmosSelected()
    {
        if (rb.transform.position == null)
            return;

        Gizmos.DrawWireSphere(rb.transform.position, attackRange);
    }
}
