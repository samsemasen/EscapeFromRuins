using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; //index0 --> RoomLR-Spikes , index1 --> RoomLR-water , index2 --> RoomLR ,
                               //index3 --> RoomB ,index4 --> LavaRoom

    private int direction;
    public float xMoveAmount;
    public float yMoveAmount;

    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration;

    public LayerMask room;

    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[3], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false) {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        } else {
            timeBtwRoom -= Time.deltaTime;
        }
    }
    private void Move()
    {
        if (direction == 1 || direction == 2) { //MOVE RIGHT !

            if (transform.position.x < maxX) {
                Vector2 newPos = new Vector2(transform.position.x + xMoveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, 3);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3) {
                    direction = 2;
                } else if (direction == 4) {
                    direction = 5;
                }

            } else {
                direction = 5;
            }


        } else if (direction == 3 || direction == 4) { //MOVE LEFT !
            if (transform.position.x > minX) {
                Vector2 newPos = new Vector2(transform.position.x - xMoveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, 3);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                direction = Random.Range(3, 6);

            } else {
                direction = 5;
            }

        } else if (direction == 5) { //MOVE DOWN !
            if (transform.position.y > minY) {

                //replacing the room with an bottom room (index 3) before moving down
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                roomDetection.GetComponent<RoomType>().RoomDestruction();
                Instantiate(rooms[3], transform.position, Quaternion.identity);

                // MOVING DOWN
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - yMoveAmount);
                transform.position = newPos;
                int rand = Random.Range(0, 3);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                //NEXT DIRECTION
                direction = Random.Range(1, 6);

            } else {
                //STOP LEVEL GENERATION
                stopGeneration = true;
            }

        }
    }
}
