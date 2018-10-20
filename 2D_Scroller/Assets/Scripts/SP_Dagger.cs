using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Dagger : MonoBehaviour {

    public static SP_Dagger cl_SP_Dagger;

    public GameObject go_SP_Dagger;

    public Vector3 v3_SP_Dagger;

    public Transform SP_DaggerTransform;
    private Transform playerTransform;
	
	void Start () {

        playerTransform = GameObject.Find("Player").transform;


    }
	
	
	void Update () {

        v3_SP_Dagger.x = SP_DaggerTransform.position.x;
        v3_SP_Dagger.y = SP_DaggerTransform.position.y;
        v3_SP_Dagger.z = SP_DaggerTransform.position.z;

        go_SP_Dagger.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
    }
}
