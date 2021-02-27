using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour {

    public GameObject menuPrefab;

	public static bool GameIsPaused = false;
    public InputGameplay inputGameplay;

	public GameObject pauseMenuUI;
	public GameObject toolBarUI;

    bool skipFrame = false;

    private void OnEnable() => skipFrame = true;


    // Update is called once per frame
    void Update () {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();
        if (kb.escapeKey.wasPressedThisFrame && kb.escapeKey.isPressed && !skipFrame)
        {
            if (GameIsPaused)
            {
                Resume();
                inputGameplay.controls.Enable();
            }
            else
            {
                Pause();
                inputGameplay.controls.Disable();
            }
        }
        else if(skipFrame)
        {
            skipFrame = !skipFrame;
        }
    }

	public void Resume(){
		pauseMenuUI.SetActive(false);
		toolBarUI.SetActive(true);

        Destroy(pauseMenuUI);
        pauseMenuUI = Instantiate(menuPrefab, gameObject.transform);

        GameIsPaused = false;
		Cursor.lockState = CursorLockMode.Confined;

	}
	
	public void Pause(){
		pauseMenuUI.SetActive(true);
        toolBarUI.SetActive(false);

        GameIsPaused = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
