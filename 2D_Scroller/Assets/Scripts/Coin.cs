
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public static Coin cl_Coin;

    public GameObject go_Coin;
    public Vector3 v3_Coin;

    public Transform coinTransform;
    private Transform SP_CoinsTransform;
    private Transform playerTransform;
    

    void Start () {

        cl_Coin = this;
        coinTransform.GetComponent<Transform>();
       

        SP_CoinsTransform = GameObject.Find("StartPoint_Clouds").transform;
        playerTransform = GameObject.Find("Player").transform;



        float f_random;
        f_random = Random.Range(-4, 2);

        go_Coin.transform.position = new Vector3(SP_CoinsTransform.position.x + 50 + f_random, SP_CoinsTransform.position.y + f_random, SP_CoinsTransform.position.z);
    }
	

	void Update () {

        if (playerTransform.position.x - coinTransform.position.x >= 30)
        {
            Destroy(go_Coin);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Destroy(go_Coin);
            PlayerController.cl_PlaterController.CollectCoins();
            FindObjectOfType<AudioManager>().Play("CollectCoins");
        }
    }
}

