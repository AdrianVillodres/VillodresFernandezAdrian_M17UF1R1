using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private bool flip = true;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (flip)
        {
            transform.position += new Vector3(-1.5f, 0) * Time.deltaTime;
        }
        else
        {
            transform.position -= new Vector3(-1.5f, 0) * Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("TurnEnemy"))
        {
            if (flip == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                flip = false;
                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 360, 0);
                flip = true;
            }
            
        }
    }
}
