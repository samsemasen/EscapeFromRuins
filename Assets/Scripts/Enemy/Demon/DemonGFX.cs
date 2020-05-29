using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DemonGFX : MonoBehaviour
{
    public AIPath aiPath;
    void Update()
    {
        
        if(aiPath.desiredVelocity.x >= 0.01f) { // loking right ?
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //transform.Rotate(0f, 180f, 0f);
        }else if(aiPath.desiredVelocity.x <= 0.01f) { // looking left ?
            transform.localScale = new Vector3(1f, 1f, 1f);
            //transform.Rotate(0f, 0f, 0f);
        }
    }
}
