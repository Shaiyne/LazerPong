using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Movement
    PlayerMovement playerMovement;
    [SerializeField] bool canMove = false;
    [SerializeField] float moveSpeed;
    #endregion
    #region Physics
    PlayerPhysicsController playerPhysics;
    float jumpWaitingTime = 0.8f;
    #endregion
    #region Animation
    protected internal Animator animator;
    PlayerAnimationController animationController;
    #endregion

    private void Awake()
    {
        playerMovement = new PlayerMovement(this);
        playerPhysics = GetComponent<PlayerPhysicsController>();
        animator = GetComponent<Animator>();
        animationController = new PlayerAnimationController(this);
    }
    private void OnEnable()
    {
        PlayerSignals.Instance.onJumpAction += OnJumpAction;
        CoreSignals.Instance.onGameBegin += OnGameBegin;
        CoreSignals.Instance.onGameEnded += OnGameEnded;
    }
    private void OnDisable()
    {
        PlayerSignals.Instance.onJumpAction -= OnJumpAction;
        CoreSignals.Instance.onGameBegin -= OnGameBegin;
        CoreSignals.Instance.onGameEnded -= OnGameEnded;
    }


    private void Update()
    {
        if (canMove)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                playerMovement.PlayerMove(moveSpeed);
                SetAnimatonStates(PlayerAnimationStates.Runs);

            }
        }
        
    }
    #region Physics
    protected internal void SetPlayerCollider(bool value)
    {
        playerPhysics.SetCollider(value);
    }
    private void OnJumpAction()
    {
        playerPhysics.PlayerJump();
        this.Wait(jumpWaitingTime, () =>
        {
            playerPhysics.PlayerJumpEnd();
        });
    }
    #endregion
    #region Animaton
    protected internal void SetAnimatonStates(PlayerAnimationStates playerAnimation)
    {
        animationController.ChangePlayerAnimation(playerAnimation);
    }
    #endregion
    #region Core
    private void OnGameBegin()
    {
        canMove = true;
    }
    private void OnGameEnded()
    {
        canMove = false;
        GetComponentInChildren<PlayerPointPhysicsController>().transform.gameObject.SetActive(false);

    }
    #endregion
}
