using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorit : MonoBehaviour
{

    public static Meteorit cl_Meteorit;

    public GameObject go_Meteorit;
    public GameObject go_flameInst;
    public GameObject go_explosionInst;
    public Transform meteoritTransform;

    private Transform playerTransform;
    private Transform SP_meteoritTransform;

    public Vector3 v3_Meteorit;


    void Start()
    {

        cl_Meteorit = this;

        meteoritTransform = GameObject.Find("Meteorit").transform;
        playerTransform = GameObject.Find("Player").transform;
        SP_meteoritTransform = GameObject.Find("StartPoint_Meteorit").transform;

        FindObjectOfType<AudioManager>().Play("Meteor");

        if (this.gameObject.name != "meteorit")
        {
            
            go_Meteorit.name = "meteorit_clone";
            go_flameInst = GameObject.Find("flame_clone");
            go_explosionInst = GameObject.Find("explosion");
            float f_random;
            f_random = Random.Range(-5, 5);
            go_Meteorit.transform.position = new Vector3(SP_meteoritTransform.position.x + f_random, SP_meteoritTransform.position.y + 5, SP_meteoritTransform.position.z);
            float f_randomScale;
            f_randomScale = Random.Range(0.2f, 0.5f);
            go_Meteorit.transform.localScale = new Vector3(f_randomScale, f_randomScale, f_randomScale);


        }



    }



    void Update()
    {

        if (this.gameObject.name != "meteorit")
        {

            
            float f_random;
            f_random = Random.Range(0.01f, 0.06f);
            go_Meteorit.transform.Translate(new Vector3(f_random, 0, 0));

            v3_Meteorit.x = meteoritTransform.position.x;
            v3_Meteorit.y = meteoritTransform.position.y;
            v3_Meteorit.z = meteoritTransform.position.z;

        
            bool b_hitGround = false;
            if (meteoritTransform.position.y < -4.5f && b_hitGround == false)
            {
                b_hitGround = true;
                Instantiate(go_flameInst, v3_Meteorit, new Quaternion(0, 0, 0, 0));
                //Instantiate(go_explosionInst, v3_Meteorit, new Quaternion(0, 0, 0, 0));
                FindObjectOfType<AudioManager>().Play("Explosion");
                Destroy(go_Meteorit);
                b_hitGround = false;
            }
            if (meteoritTransform.position.y > -4.5f)
            {
                b_hitGround = false;
            }
        }
    }
}