using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorit : MonoBehaviour
{

    public static Meteorit cl_Meteorit;

    public GameObject go_Meteorit;
    public GameObject go_flameInst;
    public GameObject go_explosionInst;
    public Transform meteoritCloneTransform;

    public GameObject PauseMenuInst;
    public GameObject DeadMenuInst;

    private Transform playerTransform;
    private Transform SP_meteoritTransform;

    public Vector3 v3_Meteorit;

    private float f_meteoritTouch;
   
    void Start()
    {

        cl_Meteorit = this;

        
        playerTransform = GameObject.Find("Player").transform;
        SP_meteoritTransform = GameObject.Find("StartPoint_Meteorit").transform;
        go_explosionInst = GameObject.Find("explosion");
        go_flameInst = GameObject.Find("flame");
        
        FindObjectOfType<AudioManager>().Play("Meteor");

        if (this.gameObject.name != "meteorit")
        {
            
            go_Meteorit.name = "meteorit_clone";
            meteoritCloneTransform = GameObject.Find("meteorit_clone").transform;
            float f_random;
            f_random = Random.Range(-5, 5);
            //go_Meteorit.transform.position = new Vector3(SP_meteoritTransform.position.x + f_random, SP_meteoritTransform.position.y + 5, SP_meteoritTransform.position.z);
            float f_randomScale;
            f_randomScale = Random.Range(0.2f, 0.5f);
            go_Meteorit.transform.localScale = new Vector3(f_randomScale, f_randomScale, f_randomScale);


        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && f_meteoritTouch == 0 && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            f_meteoritTouch++;
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            PlayerController.cl_PlaterController.LoosingHealth();
            PlayerController.cl_PlaterController.sr_player.color = Color.red;
        }

    }

        void Update()
    {

        if (this.gameObject.name != "meteorit" && PauseMenuInst.activeSelf == false && DeadMenuInst.activeSelf == false)
        {

            
            float f_random;
            f_random = Random.Range(0.01f, 0.06f);
            go_Meteorit.transform.Translate(new Vector3(f_random, 0, 0));
            
            v3_Meteorit.x = meteoritCloneTransform.position.x;
            v3_Meteorit.y = meteoritCloneTransform.position.y;
            v3_Meteorit.z = meteoritCloneTransform.position.z;

        
            
            if (meteoritCloneTransform.position.y <= -4.5f)
            {
                
                Instantiate(go_explosionInst, v3_Meteorit, new Quaternion(0, 0, 0, 0));
             
                //go_flameInst.transform.position = new Vector3(meteoritCloneTransform.position.x + 2, meteoritCloneTransform.position.y, meteoritCloneTransform.position.z);
                //Instantiate(go_explosionInst, v3_Meteorit, new Quaternion(0, 0, 0, 0));
                FindObjectOfType<AudioManager>().Play("Explosion");
                Destroy(go_Meteorit);
                
            }

            if (meteoritCloneTransform.position.x + 1 < PlayerController.cl_PlaterController.playerTransform.position.x && PlayerController.cl_PlaterController.b_IsDead == false)
            {
                f_meteoritTouch = 0;
            }
        }
    }
}