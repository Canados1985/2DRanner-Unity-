using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public static PauseMenu cl_PauseMenu;

    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject startMenuInst;

	void Start () {

        pauseMenuUI.SetActive(false);

    }
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && startMenuInst.active == false && PlayerController.cl_PlaterController.b_IsDead == false)
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }

	}


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
