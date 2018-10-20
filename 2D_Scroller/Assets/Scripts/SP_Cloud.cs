using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Cloud : MonoBehaviour {

    public static SP_Cloud cl_SP_Cloud;

    public GameObject go_spCloud;
    public Vector3 v3_spawnPoint;
    public Transform SpawnPointTransform;

    private Transform playerTransform;
    public GameObject PauseMenuInst;

    void Start() {

        cl_SP_Cloud = this;
        playerTransform = GameObject.Find("Player").transform;
        SpawnPointTransform = GameObject.Find("StartPoint_Clouds").transform;
        
    }


    
    void Update () {


        go_spCloud.transform.position = new Vector3(playerTransform.position.x + 10, 0, transform.position.z);

        //Debug.Log(SpawnPointTransform.position.x);
        
        v3_spawnPoint.x = SpawnPointTransform.position.x;
        v3_spawnPoint.y = SpawnPointTransform.position.y;
        v3_spawnPoint.z = SpawnPointTransform.position.z;

    }
}
