using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Diving");
        rbPlayer = player.GetComponent<Rigidbody>();
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Debug.Log("Executing State: Diving");
        if (Input.GetKey(KeyCode.D))
        {
            rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.AddForce(0, -1000 * Time.deltaTime, 0, ForceMode.VelocityChange);
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
