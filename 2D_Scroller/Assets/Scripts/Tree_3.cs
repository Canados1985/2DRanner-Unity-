using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_3 : MonoBehaviour {


    public static Tree_3 cl_Tree_3;

    public GameObject go_Tree_3;

    public Transform Tree_3Transform;
    public Transform spawnpointTransform;
    private Transform playerTransform;

    void Start () {

        cl_Tree_3 = this;
        Tree_3Transform.GetComponent<Transform>();
        
        playerTransform = GameObject.Find("Player").transform;

        if (this.gameObject.name != "Tree_3")
        {

            Random.seed = 200;
            float f_random;
            f_random = Random.Range(10, 120);

            go_Tree_3.transform.position = new Vector3(spawnpointTransform.position.x + Random.value + f_random, -3.45f, spawnpointTransform.position.z);
        }
    }
	
	
	void Update () {

        if (this.gameObject.name != "Tree_3")
        {
            if (playerTransform.position.x - Tree_3Transform.position.x >= 50)
            {
                Destroy(go_Tree_3);
                //float f_random;
                //f_random = Random.Range(15, 40);
                //go_Tree_3.transform.position = new Vector3(spawnpointTransform.position.x + f_random, -3.45f, spawnpointTransform.position.z);
            }
        }
    }
}
