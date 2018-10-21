using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Trees : MonoBehaviour {

    public static SP_Trees cl_SP_Trees;

    public GameObject go_SP_Trees;

    public GameObject go_Tree1; // Tree1 Inst
    public GameObject go_Tree2; // Tree2 Inst 
    public GameObject go_Tree3; // Tree3 Inst
    public GameObject go_Tree4; // Tree4 Inst

    public Vector3 v3_sp_Trees;

    public Transform spTreesTransform;
    private Transform playerTransform;

    private float f_TreesSpawnCounter;



    void Start () {

        cl_SP_Trees = this;
        playerTransform = GameObject.Find("Player").transform;

        spTreesTransform = GameObject.Find("StartPoint_Clouds").transform;

        f_TreesSpawnCounter = 150;
    }


    //Spawn Trees
    public void SpawnTrees()
    {
        float f_random;
       
        f_random = Random.Range(1, 4);


        if (f_random == 1 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            Instantiate(go_Tree1, v3_sp_Trees, new Quaternion(0, 0, 0, 0));
            Random.seed = 100;
            f_random = Random.Range(50, 500);
            f_TreesSpawnCounter = f_random;
        }
        if (f_random == 2 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            Instantiate(go_Tree2, v3_sp_Trees, new Quaternion(0, 0, 0, 0));
            Random.seed = 100;
            f_random = Random.Range(50, 500);
            f_TreesSpawnCounter = f_random;
        }
        if (f_random == 3 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            Instantiate(go_Tree3, v3_sp_Trees, new Quaternion(0, 0, 0, 0));
         
            Random.seed = 100;
            f_random = Random.Range(50, 500);
            f_TreesSpawnCounter = f_random;
        }
        if (f_random == 4 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            Instantiate(go_Tree4, v3_sp_Trees, new Quaternion(0, 0, 0, 0));
            
            Random.seed = 100;
            f_random = Random.Range(50, 500);
            f_TreesSpawnCounter = f_random;
        }


    }



    void Update () {

        f_TreesSpawnCounter--;

        go_SP_Trees.transform.position = new Vector3(playerTransform.position.x + 20, -5, transform.position.z);

        v3_sp_Trees.x = spTreesTransform.position.x;
        v3_sp_Trees.y = spTreesTransform.position.y;
        v3_sp_Trees.z = spTreesTransform.position.z;


        //Counter for Spawn Trees
        if (f_TreesSpawnCounter <= 0 && PlayerController.cl_PlaterController.b_IsDead == false && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {

            SpawnTrees();
        }
    }
}
