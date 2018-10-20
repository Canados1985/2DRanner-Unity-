using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    public static Heart cl_Heart;

    public GameObject go_Heart;

    public Transform heartTransform;
    private Transform playerTransform;
    private Transform SP_heartTransform;
        
    private float f_counter;
	
	void Start () {

        cl_Heart = this;

        heartTransform = GameObject.Find("heart").transform;
        playerTransform = GameObject.Find("Player").transform;
        SP_heartTransform = GameObject.Find("Startpoint_Heart").transform;

        if (this.gameObject.name != "heart")
        {
            go_Heart.name = "heart_clone";
            float f_random;
            f_random = Random.Range(-3,0.5f);

            go_Heart.transform.position = new Vector3(SP_heartTransform.position.x + 50, SP_heartTransform.position.y + f_random, SP_heartTransform.position.z);
        }
    }


    void Update () {


        if (this.gameObject.name != "heart")
        {
            go_Heart.transform.Rotate(new Vector3(0, 2.5f, 0));

            if (heartTransform.position.x + 5 <= playerTransform.position.x)
            {
                f_counter = 0;
                Debug.Log("f_counter" + f_counter);

            }

            if (playerTransform.position.x - heartTransform.position.x >= 30)
            {
                Destroy(go_Heart);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && f_counter == 0)
        {
            f_counter = 1;
            Destroy(go_Heart);
            PlayerController.cl_PlaterController.i_Life++;
            FindObjectOfType<AudioManager>().Play("HeartPickUp");
        }
    }
}
