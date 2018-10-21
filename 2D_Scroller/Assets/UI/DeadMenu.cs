using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeadMenu : MonoBehaviour {

    public static DeadMenu cl_DeadMenu;

    public GameObject go_DeadMenuUI;
    public GameObject go_StartMenuUI;


	void Start () {

        go_DeadMenuUI.SetActive(false);

        go_StartMenuUI = GameObject.Find("StartMenu");
            
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
            PlayerController.cl_PlaterController.PlayerNameUI_NEW.text = PlayerController.cl_PlaterController.PlayerNameUI_OLD.text;
            PlayerController.cl_PlaterController.PlayerNameUI_NEW.text = PlayerController.cl_PlaterController.PlayerNameIF_EXIST.text;


    }

    public void BackToMenu()
    {
        PlayerController.cl_PlaterController.PlayerNameUI_NEW.text = PlayerController.cl_PlaterController.PlayerNameUI_OLD.text;
        PlayerController.cl_PlaterController.PlayerNameUI_NEW.text = PlayerController.cl_PlaterController.PlayerNameIF_EXIST.text;
        
    }

    public void ExitGame()
    {
        PlayerController.cl_PlaterController.PlayerNameUI_NEW.text = PlayerController.cl_PlaterController.PlayerNameUI_OLD.text;
        PlayerController.cl_PlaterController.PlayerNameUI_NEW.text = PlayerController.cl_PlaterController.PlayerNameIF_EXIST.text;
        
        Application.Quit();
    }
}
