using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SuperJumpState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    public void Enter(Player player)
    {
        Debug.Log("Entering State: SuperJump");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.velocity = new Vector3(0, 30, 0);
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}