using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;
    public bool isPaused;
    public GameObject pauseMenuCanvas;

    // Update is called once per frame
    void Update()
    {
        if(isPaused){
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else{
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseUnpause();
        }
        
    }
    public void PauseUnpause(){
        isPaused = !isPaused;
    }
    public void resume(){
        isPaused = false;

    }

    public void LevelSelect(){
        Application.LoadLevel (this.levelSelect);

    }

    public void Quit(){
        Application.LoadLevel (this.mainMenu);
    }
}
