using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D _rb;
    int _speed = 1;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer.flipX = true;
    }

    void Update()
    {
        _rb.velocity = new Vector2(-_speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("TurnEnemy"))
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
            
        }
    }
}
