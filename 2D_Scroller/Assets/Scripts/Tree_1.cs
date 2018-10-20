using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_1 : MonoBehaviour {

    public static Tree_1 cl_Tree_1;

    public GameObject go_Tree_1;

    public Transform Tree_1Transform;
    public Transform spawnpointTransform;
    private Transform playerTransform;
    
    void Start () {

        cl_Tree_1 = this;
        Tree_1Transform.GetComponent<Transform>();
        
        playerTransform = GameObject.Find("Player").transform;

        if (this.gameObject.name != "Tree_1")
        {

            Random.seed = 100;
            float f_random;
            f_random = Random.Range(10, 50);

            go_Tree_1.transform.position = new Vector3(spawnpointTransform.position.x + Random.value + f_random, -3.45f, spawnpointTransform.position.z);

        }
    }
	
	
	void Update () {

        if (this.gameObject.name != "Tree_1")
        {

            if (playerTransform.position.x - Tree_1Transform.position.x >= 20)
            {
                Destroy(go_Tree_1);
                // float f_random;
                // f_random = Random.Range(5, 40);
                // go_Tree_1.transform.position = new Vector3(spawnpointTransform.position.x + f_random, -3.45f, spawnpointTransform.position.z);
            }
        }
	}
}
