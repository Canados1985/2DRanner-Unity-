using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour {

    public static StartMenu cl_StartMenu;

    public GameObject go_StartMenuUI;

    public string s_name;    

    public bool b_StartMenu_Is_Active = true;

	void Start () {

        go_StartMenuUI.SetActive(true); 
        Time.timeScale = 0f;
        b_StartMenu_Is_Active = true;

    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("StoredName", s_name);
        s_name = PlayerController.cl_PlaterController.s_playerName;
    }



	void Update () {

        PlayerPrefs.SetString("StoredName", s_name);
        s_name = PlayerController.cl_PlaterController.s_playerName;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonStartGame();
        }

    }


    public void ButtonStartGame()
    {
        go_StartMenuUI.SetActive(false);
        Time.timeScale = 1f;
        b_StartMenu_Is_Active = false;
    }
}
 