using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	
	public GameObject pauseMenuUI;
	public GameObject toolBarUI;
    public GameObject playerScripts;
	//public GameObject mouseScripts;
	
	// Update is called once per frame
	void Update () {
        Act();
	}

    void Act()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
	
	public void Resume(){
		pauseMenuUI.SetActive(false);
		toolBarUI.SetActive(true);

        playerScripts.GetComponent<PlayerController>().enabled = true;
        playerScripts.GetComponent<PlayerMotor>().enabled = true;

        GameIsPaused = false;
		Cursor.lockState = CursorLockMode.Confined;

	}
	
	public void Pause(){
		pauseMenuUI.SetActive(true);
		toolBarUI.SetActive(false);

        playerScripts.GetComponent<PlayerController>().enabled = false;
        playerScripts.GetComponent<PlayerMotor>().enabled = false;

        GameIsPaused = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
