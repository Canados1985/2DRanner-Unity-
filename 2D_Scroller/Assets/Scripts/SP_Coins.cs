using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Coins : MonoBehaviour {

    public static SP_Coins cl_SP_Coins;

    public GameObject go_SP_Coins;
    public Vector3 v3_SP_Coins;
    public Transform SP_CoinsTransform;

    private Transform playerTransform;
    public GameObject coinInst;
    public GameObject PauseMenuInst;
    private int i_counter;

    void Start () {

        cl_SP_Coins = this;
        playerTransform = GameObject.Find("Player").transform;
        SP_CoinsTransform = GameObject.Find("StartPoint_Coin").transform;
        coinInst = GameObject.Find("coin");

        i_counter = 100;


    }
	
	
	void Update () {


        go_SP_Coins.transform.position = new Vector3(playerTransform.position.x + 20, 0, transform.position.z);

        //Debug.Log(SpawnPointTransform.position.x);

        v3_SP_Coins.x = SP_CoinsTransform.position.x;
        v3_SP_Coins.y = SP_CoinsTransform.position.y;
        v3_SP_Coins.z = SP_CoinsTransform.position.z;

    }

    private void FixedUpdate()
    {
        i_counter--;

        
        if (i_counter <= 0  && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            float f_random;
            f_random = Random.Range(-2, 5);
            i_counter = 100;
            Instantiate(Coin.cl_Coin.go_Coin, v3_SP_Coins, new Quaternion(0, 0, 0, 0));
            go_SP_Coins.transform.position = new Vector3(playerTransform.position.x + 20, transform.position.y + f_random, transform.position.z);

        }

    }
}
