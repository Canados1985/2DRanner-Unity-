using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public static Wave cl_Wave;

    public GameObject go_Wave;
    private Transform playerTransform;
    public Animator waveAnimator;


    void Start () {
        playerTransform = GameObject.Find("Player").transform;
    }
    
	
	
	void Update () {


        if (playerTransform.position.x - go_Wave.transform.position.x >= 20)
        {
            go_Wave.transform.position = new Vector3(go_Wave.transform.position.x + 8.5f, 0, playerTransform.position.z);
        }

        if(go_Wave.transform.position.x < playerTransform.position.x)
        {
            go_Wave.transform.position = new Vector3(go_Wave.transform.position.x + 0.05f, -4.1f, playerTransform.position.z);
        }

        if (go_Wave.transform.position.x - playerTransform.position.x >= 0)
        {
            Debug.Log("PLAYER DEAD");
            PlayerController.cl_PlaterController.b_IsDead = true;
            waveAnimator.SetBool("If_Player_IsDead", true);
        }


        //Debug.Log(go_Wave.transform.position.x);
    }
}
