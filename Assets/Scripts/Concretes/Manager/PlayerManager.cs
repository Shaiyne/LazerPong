using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Movement
    PlayerMovement playerMovement;
    [SerializeField] bool canMove = true;
    [SerializeField] float moveSpeed;
    float jumpWaitingTime = 0.6f;
    #endregion
    #region Physics
    PlayerPhysicsController playerPhysics;
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
    #region Movement
    private void OnJumpAction()
    {
        SetAnimatonStates(PlayerAnimationStates.Jumps);
        playerMovement.PlayerJump();
        StartCoroutine(JumpTime(jumpWaitingTime));
    }

    IEnumerator JumpTime(float JumpWaitingTime)
    {
        yield return new WaitForSecondsRealtime(JumpWaitingTime);
        transform.localScale = new Vector3(2f, 2f, 2f);
        SetPlayerCollider(true);
    }
    #endregion
    #region Physics
    protected internal void SetPlayerCollider(bool value)
    {
        playerPhysics.SetCollider(value);
    }
    #endregion
    #region Animaton
    protected internal void SetAnimatonStates(PlayerAnimationStates playerAnimation)
    {
        animationController.ChangePlayerAnimation(playerAnimation);
    }
    #endregion
}
