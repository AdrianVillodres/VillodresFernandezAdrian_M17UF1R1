using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MainCharacter : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject ResetPoint;
    private bool disabled = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    }

    public void DisablePlayer()
    {
        disabled = true;
    }

    public void ResetPlayer()
    {
        transform.position = ResetPoint.transform.position;
        disabled = false;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1f);
        Debug.DrawLine(transform.position, transform.position - transform.up * 1f, Color.red);

        RaycastHit2D hitup = Physics2D.Raycast(transform.position, -transform.up, -1f);
        Debug.DrawLine(transform.position, transform.position - transform.up * -1f, Color.red);

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
}
