using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour {

    public static Dagger cl_Dagger;


    public GameObject go_Dagger;
    public Rigidbody2D rb_Dagger;

    public Transform daggerTransform;
    public Transform playerTransform;
    

    public float f_moveSpeed = 30f;
    private float f_rotationSpeed = 200f;



	void Start () {

       

        playerTransform = GameObject.Find("Player").transform;
        FindObjectOfType<AudioManager>().Play("ThrowKnife");

        go_Dagger.transform.position = new Vector3(daggerTransform.position.x, daggerTransform.position.y, daggerTransform.position.z);
    }

    private void OnEnable()
    {
        Invoke("Disable", 0.5f);
        FindObjectOfType<AudioManager>().Play("ThrowKnife");
    }

    private void Disable()
    {
        go_Dagger.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("ThrowKnife");
    }

    void Update () {



        go_Dagger.transform.Translate(new Vector3(f_moveSpeed * Time.deltaTime, 0, 0), Space.World);
        go_Dagger.transform.Rotate(new Vector3(0, 0, -f_moveSpeed));

        //transform.Rotate(0,0,90);

        //if (go_Dagger.transform.position.x >= playerTransform.position.x + 200)
        //{    
                //go_Dagger.SetActive(false);      
        //}

        //daggerTransform = (new Quaternion(daggerTransform.rotation.x, daggerTransform.rotation.y, daggerTransform.rotation.z +5, 0));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("DUGGER IS DESTROYED");
            go_Dagger.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("ThrowKnife");
            FindObjectOfType<AudioManager>().Play("KnifeHit");
            PlayerController.cl_PlaterController.i_Kills++;
            
        }


    }


}
