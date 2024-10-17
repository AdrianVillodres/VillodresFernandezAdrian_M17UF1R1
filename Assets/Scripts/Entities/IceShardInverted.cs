using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShardInverted : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        SetIceShardInverted();
    }

    public void SetIceShardInverted()
    {
        _rb.velocity = new Vector2(_speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Spawner.spawner.Push(this.gameObject);
    }

    void Update()
    {
        
    }
    
}

