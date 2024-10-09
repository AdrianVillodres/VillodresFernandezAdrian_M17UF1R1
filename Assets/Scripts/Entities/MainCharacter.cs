using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainCharacter : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
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
