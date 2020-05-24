using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] whichRow; // row1 = 5f, row2 =-5f ,row3 =-15f, row4=-25f;
    float randX;
    
    
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(0f, 60f);
            int rand = Random.Range(0,4);
            whereToSpawn = new Vector2(randX, whichRow[rand].transform.position.y);
            int randEnemy = Random.Range(0, 2);
            Instantiate(enemies[randEnemy], whereToSpawn, Quaternion.identity);


        }
    }
}
