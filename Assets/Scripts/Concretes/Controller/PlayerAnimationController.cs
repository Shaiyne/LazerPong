using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{
    PlayerManager player;
    public PlayerAnimationController(PlayerManager playerManager)
    {
        player = playerManager;
    }
    public void ChangePlayerAnimation(PlayerAnimationStates animationStates)
    {
        switch (animationStates)
        {
            case PlayerAnimationStates.Idles:
                player.animator.Play(animationStates.ToString());
                break;
            case PlayerAnimationStates.Runs:
                player.animator.Play(animationStates.ToString());
                break;
            case PlayerAnimationStates.Jumps:
                player.animator.Play(animationStates.ToString());
                break;
        }
    }
}
