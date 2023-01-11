using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    PlayerManager player;
    public PlayerMovement(PlayerManager playerManager)
    {
        player = playerManager;
    }
    public void PlayerMove(float moveSpeed)
    {
        if (Input.touchCount>0)
        {
            float rotX = Input.GetTouch(0).deltaPosition.x * Time.deltaTime * moveSpeed;
            float rotY = Input.GetTouch(0).deltaPosition.y * Time.deltaTime * moveSpeed;
            player.transform.position += new Vector3(rotX, rotY, 0);
            if (rotX < 0)
            {
                player.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (rotX >= 0)
            {
                player.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        //player.SetAnimatonStates(PlayerAnimationStates.Runs);
    }

    public void PlayerJump()
    {
        player.transform.localScale = new Vector3(2.7f, 2.7f, 2.7f);
        player.SetPlayerCollider(false);
    }
}
