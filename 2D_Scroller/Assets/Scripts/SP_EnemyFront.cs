using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_EnemyFront : MonoBehaviour {

    public static SP_EnemyFront cl_SP_EnemyFront;

    public GameObject go_SP_EnemyFront;
    public GameObject go_EnemyMaleInst;
    public GameObject go_EnemyFemaleInst;
    public GameObject PauseMenuInst;

    public Vector3 v3_SP_EnemyFront;

    public Transform SP_EnemyFrontTransform;
    private Transform playerTransform;

    private float f_counter;

    void Start () {

        cl_SP_EnemyFront = this;
        f_counter = Random.Range(100, 500);
        playerTransform = GameObject.Find("Player").transform;
        SP_EnemyFrontTransform = GameObject.Find("StartPoint_EF").transform;
    }

    public void SpawnFrontEnemy()
    {

        float f_random;
        f_random = Random.seed;
        f_random = Random.Range(0, 50);


        if (f_random < 25 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            Instantiate(go_EnemyMaleInst, v3_SP_EnemyFront, new Quaternion(0, 0, 0, 0));
            f_random = Random.seed;
            f_counter = Random.Range(100, 500);
        }
        //For female -->
        if (f_random > 25 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            Instantiate(go_EnemyFemaleInst, v3_SP_EnemyFront, new Quaternion(0, 0, 0, 0));
            f_random = Random.seed;
            f_counter = Random.Range(100, 500);
        }

    }


    void Update () {

        f_counter--;

        if (f_counter <= 0)
        {
            SpawnFrontEnemy();
        }

        go_SP_EnemyFront.transform.position = new Vector3(playerTransform.position.x + 40, -4, transform.position.z);

        v3_SP_EnemyFront.x = SP_EnemyFrontTransform.position.x;
        v3_SP_EnemyFront.y = SP_EnemyFrontTransform.position.y;
        v3_SP_EnemyFront.z = SP_EnemyFrontTransform.position.z;
    }
}
