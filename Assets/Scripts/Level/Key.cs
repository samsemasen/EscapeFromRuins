using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") ) {

            // open the door when the key is found
            FindObjectOfType<Door>().key = true;
            Destroy(gameObject);
        }
    }
}
