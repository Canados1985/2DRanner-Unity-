using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWall : MonoBehaviour {

    public static RightWall cl_RightWall;

    public GameObject go_RightWall;

    public Transform rightWallTransform;

    private Transform playerTransform;
    private Transform backGroundTransform;
    private Transform backGroundTransform2;

    
    void Start () {

        rightWallTransform.GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").transform;
        backGroundTransform = GameObject.Find("Background").transform;
        backGroundTransform2 = GameObject.Find("Background (2)").transform;

    }



void Update ()
    {

        if (playerTransform.position.x - backGroundTransform.position.x >= -10.5f && backGroundTransform.position.x >= 0)
        {
            go_RightWall.transform.position = new Vector3(playerTransform.position.x - 10f, 0, playerTransform.position.z);
        }
        if (playerTransform.position.x - backGroundTransform2.position.x >= -10.5f && backGroundTransform2.position.x >= 0)
        {
            go_RightWall.transform.position = new Vector3(playerTransform.position.x - 10f, 0, playerTransform.position.z);
        }


        //Debug.Log(backGroundTransform2.position.x);
    }
}
