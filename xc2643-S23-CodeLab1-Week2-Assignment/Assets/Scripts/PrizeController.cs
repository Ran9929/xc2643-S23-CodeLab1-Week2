using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour
{
    public float speed = 5f;
    private float w = 0f;
    private Vector2 position;

    private void Start()
    {
        position = transform.localPosition;
    }

    void Update()
    {
        w += Time.deltaTime;
        Vector2 tmp;
        tmp.x = position.x + Mathf.Cos(w);
        tmp.y = position.y - Mathf.Sin(w);
        transform.localPosition = tmp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameManager.Instance.score++;
    }
}
