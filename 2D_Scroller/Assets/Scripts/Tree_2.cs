using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_2 : MonoBehaviour {

    public static Tree_2 cl_Tree_2;

    public GameObject go_Tree_2;

    public Transform Tree_2Transform;
    public Transform spawnpointTransform;
    private Transform playerTransform;

    void Start () {

        cl_Tree_2 = this;
        Tree_2Transform.GetComponent<Transform>();
        
        playerTransform = GameObject.Find("Player").transform;

        if (this.gameObject.name != "Tree_2")
        {

            Random.seed = 200;
            float f_random;
            f_random = Random.Range(10, 50);

            go_Tree_2.transform.position = new Vector3(spawnpointTransform.position.x + Random.value + f_random, -2.95f, spawnpointTransform.position.z);
        }
    }


    void Update() {

        if (this.gameObject.name != "Tree_2")
        {
            if (playerTransform.position.x - Tree_2Transform.position.x >= 50)
            {
                Destroy(go_Tree_2);
                //float f_random;
                // f_random = Random.Range(10, 50);
                // go_Tree_2.transform.position = new Vector3(spawnpointTransform.position.x + f_random, -2.95f, spawnpointTransform.position.z);
            }
        }
    }
}
