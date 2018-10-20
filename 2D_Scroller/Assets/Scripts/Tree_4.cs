using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_4 : MonoBehaviour {


    public static Tree_4 cl_Tree_4;

    public GameObject go_Tree_4;

    public Transform Tree_4Transform;
    public Transform spawnpointTransform;
    private Transform playerTransform;

    void Start () {

        cl_Tree_4 = this;
        Tree_4Transform.GetComponent<Transform>();
        
        playerTransform = GameObject.Find("Player").transform;


        if (this.gameObject.name != "Tree_4")
        {
            Random.seed = 200;
            float f_random;
            f_random = Random.Range(10, 80);

            go_Tree_4.transform.position = new Vector3(spawnpointTransform.position.x + Random.value + f_random, -3.45f, spawnpointTransform.position.z);
        }
    }
	
	
	void Update () {

        if (this.gameObject.name != "Tree_4")
        {

            if (playerTransform.position.x - Tree_4Transform.position.x >= 50)
            {
                Destroy(go_Tree_4);
                //float f_random;
                //f_random = Random.Range(1, 25);
                //go_Tree_4.transform.position = new Vector3(spawnpointTransform.position.x + f_random, -3.45f, spawnpointTransform.position.z);
            }
        }
    }
}
