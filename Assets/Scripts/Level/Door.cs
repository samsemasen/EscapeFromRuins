using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool key = false;
    public Animator DoorAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && key == true) {

            DoorAnim.SetTrigger("openDoor");
           
            // WIN!! -- > next level and smth extra??
            Debug.Log("player win !!!");
            FindObjectOfType<GameManager>().CompleteLevel();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
   
}
