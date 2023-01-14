using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    PlayerManager player;
    protected internal BoxCollider2D playerCollider;
    private void Awake()
    {
        player = GetComponent<PlayerManager>();
        playerCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LazerTag"))
        {
            CoreSignals.Instance.onGameEnded?.Invoke();
            Destroy(collision.gameObject.transform.parent.gameObject);
            FindObjectOfType<AudioManager>().Play("DieSound");
        }
    }

    public void SetCollider(bool value)
    {
        playerCollider.enabled = value;
    }

    public void PlayerJump()
    {
        FindObjectOfType<AudioManager>().Play("JumpSound");
        player.SetAnimatonStates(PlayerAnimationStates.Jumps);
        player.transform.localScale = new Vector3(4f, 4f, 4f);
        player.SetPlayerCollider(false);
    }
    public void PlayerJumpEnd()
    {
        player.transform.localScale = new Vector3(2f, 2f, 2f);
        player.SetPlayerCollider(true);
    }
}
