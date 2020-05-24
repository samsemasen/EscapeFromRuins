using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGhoul : MonoBehaviour
{
    public float speed;
    public float GroundCheckDistance;
    public float WallCheckDistance;


    private bool movingLeft = true;

    public Transform detection;
    public LayerMask whatIsGround;

    void Start()
    {
        //Ignore the collisions between layer 0 (default) and layer 8 (Room) 
        Physics2D.IgnoreLayerCollision(0, 8, true);
        
       // transform.eulerAngles = new Vector3(0, -180, 0);
    }


    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(detection.position, Vector2.down, GroundCheckDistance, whatIsGround);
        RaycastHit2D wallInfo = Physics2D.Raycast(detection.position, -transform.right, WallCheckDistance, whatIsGround);

        if (groundInfo.collider == false || wallInfo.collider == true ) {

            if (movingLeft == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }

        }
    }

}


