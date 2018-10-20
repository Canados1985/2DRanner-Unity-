using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bin : MonoBehaviour {

    public static bin cl_bin;

    public GameObject go_bin;

    public Transform binTransform;
    private Transform playerTransform;
    private Transform spTransformInst;


    void Start () {
        binTransform.GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").transform;
        spTransformInst = GameObject.Find("StartPoint_Trees").transform;
    }
	
	
	void Update () {

        

        if (playerTransform.position.x - binTransform.position.x >= 50)
        {
            float f_random;
            f_random = Random.Range(1, 35);
            go_bin.transform.position = new Vector3(spTransformInst.position.x + f_random, binTransform.position.y, spTransformInst.position.z);
        }
    }
}
