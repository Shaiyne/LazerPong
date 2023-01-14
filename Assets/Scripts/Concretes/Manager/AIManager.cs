using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    AIController controller;
    AIPhysics aIPhysics;
    bool canMove;

    [SerializeField] protected internal bool SetLayer;
    [SerializeField] protected internal bool LeftSideBool;
    [SerializeField] protected internal bool RightSideBool;
    private void Awake()
    {
        controller = GetComponent<AIController>();
        aIPhysics = GetComponent<AIPhysics>();
    }
    private void OnEnable()
    {
        CoreSignals.Instance.onLeftSide += OnLeftSide;
        CoreSignals.Instance.onRightSide += OnRightSide;
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }
    private void OnDisable()
    {
        CoreSignals.Instance.onLeftSide -= OnLeftSide;
        CoreSignals.Instance.onRightSide -= OnRightSide;
        CoreSignals.Instance.onGameBegin -= OnGameBegin;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }
    private void Update()
    {
        if (canMove)
        {
            if (SetLayer)
            {
                if (RightSideBool)
                {
                    controller.FollowBall();
                }
                else
                {
                    controller.BackToStartPosition();
                }
            }
            if (!SetLayer)
            {
                if (LeftSideBool)
                {
                    controller.FollowBall();
                }
                else
                {
                    controller.BackToStartPosition();
                }
            }
        }
    }
    private void OnGameBegin()
    {
        canMove = true;
    }
    private void OnGameEnded()
    {
        canMove = false;
    }
    private void OnLeftSide()
    {
        controller.LeftSide();
    }
    private void OnRightSide()
    {
        controller.RightSide();
    }
}
