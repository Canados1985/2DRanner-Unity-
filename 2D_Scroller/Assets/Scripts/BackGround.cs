using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public static BackGround cl_BackGroud;

    public GameObject go_backGround;


    public Transform backgroundTransform;

    
	// Use this for initialization
	void Start () {


        backgroundTransform.GetComponent<Transform>();

    }




    // Update is called once per frame
    void Update () {



        //Moving BackGround
        if (PlayerController.cl_PlaterController.playerTransform.position.x - backgroundTransform.position.x >= 40)
        {

            backgroundTransform.transform.Translate(new Vector3(88.82f, backgroundTransform.position.y, 0));

        }

    }
}





