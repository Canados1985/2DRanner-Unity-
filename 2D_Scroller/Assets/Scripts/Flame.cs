using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {

    public static Flame cl_Flame;

    public GameObject go_Flame;

    public Transform flameTransform;
    private Transform playerTransform;
    private Transform spTransformInst;

    public int flameTouch = 0;

    void Start () {

        flameTransform.GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").transform;
        spTransformInst = GameObject.Find("StartPoint_Trees").transform;


        if (this.gameObject.name != "flame")
        {
            go_Flame.name = "flame_clone";
            go_Flame.transform.position = new Vector3(flameTransform.position.x, -4.16f, flameTransform.position.z);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && flameTouch == 0)
        {
            flameTouch++;
            PlayerController.cl_PlaterController.LoosingHealth();
            PlayerController.cl_PlaterController.sr_player.color = Color.red;
        }
    }



    void Update () {

        if (playerTransform.position.x - flameTransform.position.x >= 50)
        {
            // float f_random;
            // f_random = Random.Range(1, 25);
            // go_Flame.transform.position = new Vector3(spTransformInst.position.x + f_random, flameTransform.position.y, spTransformInst.position.z);
            Destroy(go_Flame);

        }

        if (flameTransform.position.x + 1 < PlayerController.cl_PlaterController.playerTransform.position.x && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            flameTouch = 0;
        }
    }
}
