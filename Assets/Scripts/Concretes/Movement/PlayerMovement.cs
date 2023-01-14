using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    PlayerManager player;
    float clampPosValue = 4;
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
            var clampX = Mathf.Clamp(player.transform.position.x, -4, 4);
            var clampY = Mathf.Clamp(player.transform.position.y, -4.5f, 4.5f);
            player.transform.position = new Vector3(clampX, clampY);
            if (rotX < 0)
            {
                player.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (rotX >= 0)
            {
                player.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

    }

}
