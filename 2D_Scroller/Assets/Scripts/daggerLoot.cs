using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daggerLoot : MonoBehaviour {

    public static daggerLoot cl_daggerLoot;

    public GameObject go_daggerLoot;

    public Transform daggerLootTransform;
    private Transform playerTransform;
    private Transform SP_heartTransform;

    private float f_counter;


    void Start () {

        cl_daggerLoot = this;

        daggerLootTransform = GameObject.Find("daggerLoot").transform;
        playerTransform = GameObject.Find("Player").transform;
        SP_heartTransform = GameObject.Find("Startpoint_Heart").transform;


        if (this.gameObject.name != "daggerLoot")
        {
            go_daggerLoot.name = "heart_clone";
            float f_random;
            f_random = Random.Range(-3, 0.5f);

           
           // go_daggerLoot.transform.position = new Vector3(SP_heartTransform.position.x + 50, SP_heartTransform.position.y + f_random, SP_heartTransform.position.z);

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && f_counter == 0 && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            f_counter = 1;
            Destroy(go_daggerLoot);
            PlayerController.cl_PlaterController.i_Daggers = PlayerController.cl_PlaterController.i_Daggers + 5;
            FindObjectOfType<AudioManager>().Play("KnifePickUp");
        }
    }

    

    void Update () {

        go_daggerLoot.transform.Rotate(0,2.5f,0);


        if (playerTransform.position.x - daggerLootTransform.position.x >= 30)
        {
            Destroy(go_daggerLoot);
        }
    }
}
