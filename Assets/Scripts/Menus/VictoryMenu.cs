using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
