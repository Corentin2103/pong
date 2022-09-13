using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerPaddle : Paddle
{
    public Vector2 direction { get; private set; }

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)) {
            direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            direction = Vector2.down;
        } else {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = (direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.SwitchToPlayerMaterial();
        }
    }
}
