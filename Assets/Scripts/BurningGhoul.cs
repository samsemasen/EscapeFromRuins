using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGhoul : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    
    void Start()
    {
        //Ignore the collisions between layer 0 (default) and layer 8 (Room) 
        Physics2D.IgnoreLayerCollision(0, 8, true);
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(movingRight== true) {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        } else {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
