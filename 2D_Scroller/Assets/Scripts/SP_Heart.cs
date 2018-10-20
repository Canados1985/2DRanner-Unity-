using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Heart : MonoBehaviour {

    public static SP_Heart cl_SP_Heart;

    public GameObject go_SP_Heart;
    public Vector3 v3_SP_Heart;
    public Transform SP_HeartTransform;
    

    private Transform playerTransform;
    public GameObject heartInst;
    public GameObject daggerLootInst;

    private int i_counter;


    void Start () {

        playerTransform = GameObject.Find("Player").transform;
        SP_HeartTransform = GameObject.Find("StartPoint_Heart").transform;
        heartInst = GameObject.Find("heart");
        daggerLootInst = GameObject.Find("daggerLoot");

        i_counter = 1500;
    }
	

	void Update () {

       

        go_SP_Heart.transform.position = new Vector3(playerTransform.position.x + 20, 0, transform.position.z);

        //Debug.Log(SpawnPointTransform.position.x);

        v3_SP_Heart.x = SP_HeartTransform.position.x;
        v3_SP_Heart.y = SP_HeartTransform.position.y;
        v3_SP_Heart.z = SP_HeartTransform.position.z;
    }


    private void FixedUpdate()
    {
        i_counter--;

        if (i_counter <= 0 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {

            float f_random;
            f_random = Random.seed;
            f_random = Random.Range(0, 50);

            if (f_random < 25 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
            {

                Instantiate(heartInst, v3_SP_Heart, new Quaternion(0, 0, 0, 0));
                i_counter = 1500;
            }
            if (f_random >= 25 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
            {
                Instantiate(daggerLootInst, v3_SP_Heart, new Quaternion(0, 0, 0, 0));
                daggerLootInst.transform.position = new Vector3(SP_HeartTransform.position.x + 50, SP_HeartTransform.position.y + f_random, SP_HeartTransform.position.z);
                i_counter = 1500;
            }

            
        }
    }
}
