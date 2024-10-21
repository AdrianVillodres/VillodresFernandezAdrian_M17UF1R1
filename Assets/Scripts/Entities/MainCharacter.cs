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
        if (collision.collider.gameObject.layer == 7)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("Die");

    }

    public void DisablePlayer()
    {
        disabled = true;
    }

    public void ResetPlayer()
    {
        transform.position = ResetPoint.transform.position;
        disabled = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
    }



    void Update()
    {
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
        /*private IEnumerator CharacterDeath()
        {
            DisablePlayer();
            yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[2].clip.length);
            ResetPlayer();
        }*/

    }
}
