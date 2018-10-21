using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Meteorit : MonoBehaviour {

    public static SP_Meteorit cl_SP_Meteorit;

    public GameObject go_ST_Meteorit;

    public Vector3 v3_ST_Meteorit;
    public Transform SP_MeteoritTransform;

    private Transform playerTransform;
    public GameObject meteoritInst;
    public GameObject PauseMenuInst;
    public GameObject DeadMenuInst;

    private int i_counter;

    void Start () {

        playerTransform = GameObject.Find("Player").transform;
        SP_MeteoritTransform = GameObject.Find("StartPoint_Meteorit").transform;
        meteoritInst = GameObject.Find("meteorit");

        i_counter = 500;
    }
	
	
	void Update () {

        i_counter--;
        go_ST_Meteorit.transform.position = new Vector3(playerTransform.position.x + 40, 6, transform.position.z);

        //Debug.Log(SpawnPointTransform.position.x);

        v3_ST_Meteorit.x = SP_MeteoritTransform.position.x;
        v3_ST_Meteorit.y = SP_MeteoritTransform.position.y;
        v3_ST_Meteorit.z = SP_MeteoritTransform.position.z;

    }

    private void FixedUpdate()
    {
        i_counter--;


        if (i_counter <= 0 && PlayerController.cl_PlaterController.f_horizontalMove > 0 && PauseMenuInst.activeSelf == false && DeadMenuInst.activeSelf == false)
        {
            float f_random;
            f_random = Random.Range(-2, 5);
            i_counter = 500;
            Instantiate(meteoritInst, v3_ST_Meteorit, new Quaternion(0, 0, 225, -75));
            go_ST_Meteorit.transform.position = new Vector3(meteoritInst.transform.position.x, meteoritInst.transform.position.y + 15, meteoritInst.transform.position.z);

        }

    }
}
