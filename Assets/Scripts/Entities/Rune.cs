using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rune : MonoBehaviour
{
    public int escenaUltimoCheckpoint;
    public Vector3 checkpointPosition;
    public int lastCheckpointScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lastCheckpointScene);
        if (SceneManager.GetActiveScene().buildIndex > lastCheckpointScene)
        {
            Destroy(gameObject);
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
            }
            Destroy(gameObject);
        }
    }
}
