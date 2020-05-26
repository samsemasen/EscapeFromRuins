using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public Transform[] BeginPoints;
    public Transform[] EndPoints;

    public GameObject FireBallPrefab;

    

  

    void Start()
    {
        //instantiate 4 fireballs in beginPoints
        Instantiate(FireBallPrefab, BeginPoints[0].position , Quaternion.identity);
        Instantiate(FireBallPrefab, BeginPoints[1].position , Quaternion.identity);
        Instantiate(FireBallPrefab, BeginPoints[2].position, Quaternion.identity);
        Instantiate(FireBallPrefab, BeginPoints[3].position, Quaternion.identity);

        /*
        for(int i = 0; i <= BeginPoints.Length-1; i++) {
            //transform.position = BeginPoints[i].position;
            Instantiate(FireBallPrefab, BeginPoints[i].position, Quaternion.identity);

        }
        */

    }


}
