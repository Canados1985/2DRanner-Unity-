using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public static MainCamera cl_MainCamera;
    public GameObject go_camera;
    public GameObject go_Moon;

    private Transform moonTransfom;
    private Transform playerTransform;
    private Transform backGroundTransform;
    private Transform backGroundTransform2;



    
    void Start () {

        go_Moon = GameObject.Find("Moon");
        moonTransfom = GameObject.Find("Moon").transform;
        playerTransform = GameObject.Find("Player").transform;
        backGroundTransform = GameObject.Find("Background").transform;
        backGroundTransform2 = GameObject.Find("Background (2)").transform;
        go_camera.transform.position = new Vector3(playerTransform.position.x, 0, transform.position.z);
    }
	
	
	void Update ()
    {

       

        
        if (playerTransform.position.x - backGroundTransform.position.x >= -11 && backGroundTransform.position.x - backGroundTransform.position.x == 0 && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            go_camera.transform.position = new Vector3(playerTransform.position.x, 0, transform.position.z);
            go_Moon.transform.position = new Vector3(playerTransform.position.x + 7, moonTransfom.position.y, moonTransfom.position.z);
        }

        if (playerTransform.position.x - backGroundTransform2.position.x >= -11 && PlayerController.cl_PlaterController.b_IsDead == false)
        {
             go_camera.transform.position = new Vector3(playerTransform.position.x, 0, transform.position.z);
             go_Moon.transform.position = new Vector3(playerTransform.position.x + 7, moonTransfom.position.y, moonTransfom.position.z);
        }

    }

}
