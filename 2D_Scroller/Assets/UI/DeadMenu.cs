using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeadMenu : MonoBehaviour {

    public static DeadMenu cl_DeadMenu;

    public GameObject go_DeadMenuUI;
    

	void Start () {

        go_DeadMenuUI.SetActive(false);
	}
	
	
	void Update () {


        if (PlayerController.cl_PlaterController.b_IsDead == true)

        {
            go_DeadMenuUI.SetActive(true);

        }


	}


    public void RestartGame()

    {
        Application.LoadLevel("Level1");
        go_DeadMenuUI.SetActive(false);
    }
}
