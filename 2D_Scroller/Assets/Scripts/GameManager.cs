using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager cl_GameManager;

    public Transform playerTransform; // Player transform inst
    private CharacterController2D CharacterController2DInst; // Character Controller inst
    private PlayerController PlayerInst;



    public GameObject PauseMenuInst;
    public GameObject StartMenuInst;
    public GameObject daggerInst; // Dagger Inst
    private Transform SP_DaggerInst; // Dagger SpawnPoint inst
    private List<GameObject> daggers; //Daggers Array
    
    private GameObject daggerPool; // Container for Dagger's List
    private Vector3 v3_DaggerInst; //V3 Dagger insts


    private float f_randomY;
    private int i_CloudSpawnCounter;

   

    private int i_points;

    void Start () {
        
        

        FindObjectOfType<AudioManager>().Play("MainTheme");

        daggers = new List<GameObject>();
        daggerPool = GameObject.Find("DaggerPool");
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(daggerInst);
            temp.SetActive(false);
            daggers.Add(temp);
            daggers[i].transform.parent = daggerPool.transform;
            daggers[i].name = "dagger";
        }

        cl_GameManager = this;
        i_CloudSpawnCounter = 200;
     
        playerTransform = GameObject.Find("Player").transform;

        if (daggerInst)
        {
            Debug.Log(daggerInst);
        }
        else { Debug.Log("No object name"); }


        SP_DaggerInst = GameObject.Find("StartPoint_Dagger").transform;
        CharacterController2DInst = GameObject.Find("Player").GetComponent<CharacterController2D>();
        PlayerInst = GameObject.Find("Player").GetComponent<PlayerController>();


        v3_DaggerInst.x = SP_DaggerInst.position.x;
        v3_DaggerInst.y = SP_DaggerInst.position.y;
        v3_DaggerInst.z = SP_DaggerInst.position.z;


    }

    public GameObject GetDagger()
    {
        for(int i = 0; i < 10; i++)
        {
            if (!daggers[i].activeInHierarchy)
            {
                daggers[i].SetActive(true);
                return daggers[i];
            }
        }

        GameObject temp = Instantiate(daggerInst);
        daggers.Add(temp);
        temp.SetActive(true);
        return temp;
    }


    // Spawn Clouds
    public void SpawnCloud()
    {
        i_CloudSpawnCounter = 200;
        
        //f_randomX = Random.Range(-10, -5); // Horizontal
        
        f_randomY = Random.Range(-2, 8f); //Vecrtical
        
        //SP_Cloud.cl_SP_Cloud.v3_spawnPoint.x = f_randomX;
        SP_Cloud.cl_SP_Cloud.v3_spawnPoint.y = f_randomY;
        SP_Cloud.cl_SP_Cloud.v3_spawnPoint.z = 0f;


        Object.Instantiate(Cloud.cl_cloud.go_Cloud, SP_Cloud.cl_SP_Cloud.v3_spawnPoint, new Quaternion(0, 0, 0, 0));

        //Cloud.cl_cloud.go_Cloud.transform.localScale = new Vector3(f_randomScale, f_randomScale, f_randomScale);
        
    }




    void FixedUpdate () {


        i_CloudSpawnCounter--;
      
        //Counter for Spawn Clouds
        if (i_CloudSpawnCounter <= 0 &&  PlayerController.cl_PlaterController.b_IsDead == false && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            i_CloudSpawnCounter = 200;
            SpawnCloud();
        }



        //Player points
        if (PlayerController.cl_PlaterController.f_horizontalMove > 0 && PlayerController.cl_PlaterController.f_horizontalMove > 0)
        {
            PlayerController.cl_PlaterController.Points(); 
            
            //Debug.Log(PlayerController.cl_PlaterController.i_Points);
        }

        //Debug.Log(i_TreesSpawnCounter);

    }

    private void Update()
    {

               
        //Spawn Daggers facing right
        if (Input.GetButtonDown("Throw") && CharacterController2DInst.m_FacingRight == true && PlayerController.cl_PlaterController.i_Daggers > 0 && PauseMenuInst.active == false && StartMenuInst.active == false)
        {
            //Instantiate(daggerInst, v3_DaggerInst, new Quaternion(0, 0, 0, 0));
            GameObject temp = GetDagger();
            temp.GetComponent<Dagger>().f_moveSpeed = 30f;
            temp.transform.position = SP_DaggerInst.position;
            temp.transform.rotation = SP_DaggerInst.rotation;
            //FindObjectOfType<AudioManager>().Play("ThrowKnife");
            PlayerController.cl_PlaterController.i_Daggers--;

        }
        //Spawn Daggers facing left
        if (Input.GetButtonDown("Throw") && CharacterController2DInst.m_FacingRight == false && PlayerController.cl_PlaterController.i_Daggers > 0 && PauseMenuInst.active == false && StartMenuInst.active == false)
        {
            // Instantiate(daggerInst, v3_DaggerInst, new Quaternion(0, 90, 0, 0));
            GameObject temp = GetDagger();
            temp.GetComponent<Dagger>().f_moveSpeed = -30f;
            temp.transform.position = SP_DaggerInst.position;
            temp.transform.rotation = new Quaternion(0, 90, 0, 0);
            //FindObjectOfType<AudioManager>().Play("ThrowKnife");
            PlayerController.cl_PlaterController.i_Daggers--;
        }


    }

}
