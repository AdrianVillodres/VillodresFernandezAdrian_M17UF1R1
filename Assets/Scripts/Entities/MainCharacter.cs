using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter maincharacter;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool disabled = false;
    public int escenaUltimoCheckpoint;
    public Vector3 checkpointPosition;
    public int lastCheckpointScene;
    public static bool Pause;
    public List<List<Vector3>> Positions = new List<List<Vector3>>(){
        new List<Vector3> { new (0, 0), new(7.00f, -2.93f) },
        new List<Vector3> { new (-7.23f, -2.93f), new(7.20f, 2.94f) },
        new List<Vector3> { new (-7.29f, 2.98f), new(-7.00f, -3.00f) },
        new List<Vector3> { new (7.24f, -2.97f), new(7.00f, 1.94f) },
        new List<Vector3> { new (-7.29f, 2.98f), new(-7.20f, -3.00f) },
        new List<Vector3> { new (7.02f, -2.88f), new(-7.10f, -3.00f) },
        new List<Vector3> { new (7.34f, -2.99f), new(0, 0) },
    };


    void Start()
    {
        if (MainCharacter.maincharacter != null && MainCharacter.maincharacter != this)
        {
            Destroy(gameObject);
        }
        else
        {
            MainCharacter.maincharacter = this;
            DontDestroyOnLoad(gameObject);
            Pause = false;
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Proyectile"))
        {
            DisablePlayer();
            animator.SetBool("Die", disabled);
            AudioManager.audioManager.PlayHit();
            AudioManager.audioManager.PlayDeath();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            DisablePlayer();
            animator.SetBool("Die", disabled);
            AudioManager.audioManager.PlayHit();
            AudioManager.audioManager.PlayDeath();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DisablePlayer();
            animator.SetBool("Die", disabled);
            AudioManager.audioManager.PlayHit();
            AudioManager.audioManager.PlayDeath();
        }

    }

    public void DisablePlayer()
    {
        disabled = true;
    }

    public void ResetPlayer()
    {
        SceneManager.LoadScene(escenaUltimoCheckpoint);
        transform.position = checkpointPosition;
        disabled = false;
    }

    void Update()
    {
        if (Pause)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause = true;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1f);
        Debug.DrawRay(transform.position, - transform.up * 1f, Color.red);

        RaycastHit2D hitup = Physics2D.Raycast(transform.position, -transform.up, -1f);
        Debug.DrawRay(transform.position, - transform.up * -1f, Color.red);

        bool TouchGround = hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground");
        bool TouchInvertedGround = hitup.collider != null && hitup.collider.gameObject.layer == LayerMask.NameToLayer("Ground");

        if (!disabled)
        {
            if (Time.timeScale == 0) return;

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-3f, 0) * Time.deltaTime;
                spriteRenderer.flipX = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(3f, 0) * Time.deltaTime;
                spriteRenderer.flipX = false;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
            }


            if (Input.GetKeyDown(KeyCode.Space) && (TouchGround || TouchInvertedGround))
            {
                AudioManager.audioManager.PlayJump();
                GetComponent<Rigidbody2D>().gravityScale *= -1;
                if (spriteRenderer.flipY)
                {
                    spriteRenderer.flipY = false;
                }
                else
                {
                    spriteRenderer.flipY = true;
                }

            }
        } 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoBack"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex - 1);
            MainCharacter.maincharacter.transform.position = Positions[SceneManager.GetActiveScene().buildIndex - 2][1];
        }
        else if (other.gameObject.CompareTag("GoForward"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
            MainCharacter.maincharacter.transform.position = Positions[SceneManager.GetActiveScene().buildIndex][0];
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex > lastCheckpointScene)
            {
                escenaUltimoCheckpoint = SceneManager.GetActiveScene().buildIndex;
                checkpointPosition = maincharacter.transform.position;
                lastCheckpointScene = currentSceneIndex;
                AudioManager.audioManager.PlayCheckpoint();
            }
        }

        if (other.gameObject.CompareTag("Key"))
        {
            AudioManager.audioManager.PlayWin();
            SceneManager.LoadScene("VictoryMenu");
            MainCharacter.maincharacter = null;
            Destroy(GameObject.Find("MainCharacter"));
        }
    }
}