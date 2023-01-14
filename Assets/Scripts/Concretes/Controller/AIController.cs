using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    [SerializeField]GameObject Ball;
    Vector2 clampPos;
    Vector2 firstPlace;
    float speed = 12f;
    float clampValue=4.85f;
    AIManager manager;
    private void Awake()
    {
        manager = GetComponent<AIManager>();
        firstPlace = transform.position;
        Ball = GameObject.Find("Ball");
    }

    public void FollowBall()
    {
        clampPos = new Vector2(transform.position.x, Ball.transform.position.y);
        clampPos.y = Mathf.Clamp(clampPos.y, -clampValue, clampValue);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, clampPos.y), Time.deltaTime * speed);
    }
    public void BackToStartPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(firstPlace.x, 0), Time.deltaTime * speed / 2);
    }
    public void LeftSide()
    {
        manager.LeftSideBool = true;
        manager.RightSideBool = false;
    }
    public void RightSide()
    {
        manager.LeftSideBool = false;
        manager.RightSideBool = true;
    }
}
