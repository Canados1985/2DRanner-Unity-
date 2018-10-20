using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public static Cloud cl_cloud;

    public GameObject go_Cloud;

    private Vector3 v3_Cloud;
    private float f_moveSpeed = -1.0f;
    private float f_randomScale;

    public  Transform cloudTransform;
    private Transform spawnpointTransform;
    private Transform playerTransform;


    private float f_randomY;
    private static int i_CloudSpawnCounter;


   
    void Start() {

        cl_cloud = this;
        cloudTransform.GetComponent<Transform>();
        spawnpointTransform = GameObject.Find("StartPoint_Clouds").transform;
        playerTransform = GameObject.Find("Player").transform;
        f_randomScale = Random.Range(0.3f, 6);

        go_Cloud.transform.position = new Vector3(spawnpointTransform.position.x, f_randomScale, spawnpointTransform.position.z);

    }




    
    void FixedUpdate () {

        go_Cloud.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0));



        if (playerTransform.position.x - cloudTransform.position.x >= 50)
        {
            Destroy(go_Cloud);
        }

        //Debug.Log(cloudTransform.position.x);
    }
}
