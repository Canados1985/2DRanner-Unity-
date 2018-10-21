using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour {

    public static StartMenu cl_StartMenu;

    public GameObject go_StartMenuUI;
    public GameObject go_GameUI_Inst;
    public GameObject playerControllerInst;

    public InputField playerNameIF;

    public Text playerName;
    public string st_playerName;

    public bool b_StartMenu_Is_Active = true;

	void Start () {


            playerControllerInst = GameObject.Find("Player");
            go_StartMenuUI.SetActive(true);
            Time.timeScale = 0f;
            b_StartMenu_Is_Active = true;
            st_playerName = PlayerPrefs.GetString("Name").ToString();
            playerName.text = st_playerName;

    }


    public void SaveName()
    {
        st_playerName = playerNameIF.text;
        PlayerPrefs.SetString("Name", st_playerName);
    }


    public void ButtonStartGame()
    {
        
        go_StartMenuUI.SetActive(false);
        b_StartMenu_Is_Active = false;
        Time.timeScale = 1f;
        go_GameUI_Inst.SetActive(true);

    }


    void Update () {

        playerName.text = st_playerName;


    }


        
   
}
 