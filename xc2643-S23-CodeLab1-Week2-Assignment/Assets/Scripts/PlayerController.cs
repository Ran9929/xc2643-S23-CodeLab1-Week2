using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Rigidbody2D m_Rigidbody2D;
    private Vector2 m_Movement;
    private Collider2D m_Collider2D;
    private Vector2 m_Size;
    public float moveSpeed = 5f;
    public float growSpeed = 1.01f;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider2D = GetComponent<Collider2D>();
        m_Size = m_Collider2D.bounds.size;
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, vertical);
        m_Movement.Normalize();
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.AddForce(m_Movement * moveSpeed);
        m_Rigidbody2D.velocity *= 0.99f;
    }

    public void Grow()
    {
        transform.localScale *= growSpeed;
        m_Size *= growSpeed;

    }
}
