using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GravityState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Gravity");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.useGravity = false;
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Debug.Log("Executing State: Gravity");
        if (Input.GetKeyDown(KeyCode.Z)) {
            rbPlayer.useGravity = true;
            rbPlayer.AddForce(0, 400 * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D)) {
            rbPlayer.useGravity = true;
            DivingPlayerState diveState = new DivingPlayerState();
            diveState.Enter(player);
        }
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f))
        {
            rbPlayer.useGravity = true;
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
        
    }
}