using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeButton();
        } 
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseMenu");
        MainCharacter.Pause = false;
    }

    public void RestartButton()
    {
        MainCharacter.maincharacter = null;
        Destroy(GameObject.Find("MainCharacter"));
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Rune.lastCheckpointScene = 0;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
