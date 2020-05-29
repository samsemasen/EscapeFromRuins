using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject key;
    public GameObject[] whichRow; // row1 = 5f, row2 =-5f ,row3 =-15f, row4=-25f;
    float randX;

    Vector2 whereToSpawn;
  

    void Start()
    {
        randX = Random.Range(0f, 60f);
        int rand = Random.Range(0, 4);
        whereToSpawn = new Vector2(randX, whichRow[rand].transform.position.y);

        Instantiate(key, whereToSpawn, Quaternion.identity);
    }


}
