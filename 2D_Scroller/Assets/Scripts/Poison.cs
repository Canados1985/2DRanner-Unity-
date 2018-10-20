using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour {

    public static Poison cl_Poison;

    public GameObject go_Poison;

    private Transform poisonTransform;
    private Transform playerTransform;

    private float f_movingSpeed = 2f;
	
	void Start () {

        playerTransform = GameObject.Find("Player").transform;
        poisonTransform = GameObject.Find("Poison").transform;

    }

    public void PoisonSpeedUp()
    {
        f_movingSpeed++;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerController.cl_PlaterController.b_IsDead = true;
            f_movingSpeed = 0f;
            PlayerController.cl_PlaterController.i_Life = 0;
            PlayerController.cl_PlaterController.sr_player.color = Color.red;
        }
    }


    void Update () {

        if (PlayerController.cl_PlaterController.b_IsDead == false) {

            go_Poison.transform.Translate(new Vector3(f_movingSpeed * Time.deltaTime, 0, 0));

            if (playerTransform.position.x - go_Poison.transform.position.x >= 20)
            {
                go_Poison.transform.position = new Vector3(go_Poison.transform.position.x + 8.5f, 0, playerTransform.position.z);
                //f_movingSpeed++;
            }

        }






    }
}
