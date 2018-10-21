using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    public static GameUI cl_GameUI;

    public GameObject go_GameUI;

    public GameObject go_StartMenuUI_Inst;
    public GameObject go_PauseMenuUI_Inst;

	void Start () {

        go_GameUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (go_StartMenuUI_Inst.activeSelf == true)
        {
            go_GameUI.SetActive(false);
        }

    }
}
