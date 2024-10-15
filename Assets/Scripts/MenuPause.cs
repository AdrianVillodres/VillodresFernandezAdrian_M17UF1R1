using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public bool pasarNivel;
    public bool isNivel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            //SceneManager.LoadScene(2);
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            } else
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(0, LoadSceneMode.Additive);
            }
            
        }

    }
}
