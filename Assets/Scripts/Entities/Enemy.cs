using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private bool flip = true;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        RaycastHit2D hitground = Physics2D.Raycast(transform.position - new Vector3(0, boxCollider.size.y * 2.5f, 0), -Vector2.right, 1.1f);
        Debug.DrawRay(transform.position - new Vector3(0, boxCollider.size.y * 2.5f, 0), -Vector2.right * 1.1f, Color.blue);

        RaycastHit2D hitground2 = Physics2D.Raycast(transform.position - new Vector3(0, boxCollider.size.y * 2.5f, 0), Vector2.right, 1.1f);
        Debug.DrawRay(transform.position - new Vector3(0, boxCollider.size.y * 2.5f, 0), Vector2.right * 1.1f, Color.red);

        bool TouchGround = hitground.collider != null && hitground.collider.gameObject.layer == LayerMask.NameToLayer("Ground");
        bool TouchGround2 = hitground2.collider != null && hitground2.collider.gameObject.layer == LayerMask.NameToLayer("Ground");

        if (flip)
        {
            transform.position += new Vector3(-1.5f, 0) * Time.deltaTime;
            if (TouchGround)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                flip = false;
            }
        }
        else
        {
            transform.position -= new Vector3(-1.5f, 0) * Time.deltaTime;
            if (TouchGround2)
            {
                transform.eulerAngles = new Vector3(0, 360, 0);
                flip = true;
            }
        }
    }
}
