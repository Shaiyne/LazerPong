using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 LastVelocity;
    float _speed=15;
    int ballDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ballDirection = Random.Range(0, 2);
        if(ballDirection == 0)
        {
            ballDirection = -20;
        }
        else
        {
            ballDirection = 20;
        }
    }
    private void OnEnable()
    {
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }
    private void OnDisable()
    {
        CoreSignals.Instance.onGameBegin -= OnGameBegin;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }
    private void OnGameBegin()
    {
        rb.AddForce(new Vector2(ballDirection * _speed, ballDirection * _speed));
    }

    void Update()
    {
        LastVelocity = rb.velocity;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = LastVelocity.magnitude;
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    private void OnGameEnded()
    {
        rb.velocity = new Vector2(0, 0);
    }


}
