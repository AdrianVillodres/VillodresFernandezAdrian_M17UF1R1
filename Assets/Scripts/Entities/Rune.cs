using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rune : MonoBehaviour
{
    public int escenaUltimoCheckpoint;
    public Vector3 checkpointPosition;
    public static int lastCheckpointScene = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex <= lastCheckpointScene)
        {
            Destroy(GameObject.Find("Checkpoint"));
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex > lastCheckpointScene)
            {
                escenaUltimoCheckpoint = SceneManager.GetActiveScene().buildIndex;
                checkpointPosition = MainCharacter.maincharacter.transform.position;
                lastCheckpointScene = currentSceneIndex;
                Destroy(GameObject.Find("Checkpoint"));
            }
            
        }
    }
}
